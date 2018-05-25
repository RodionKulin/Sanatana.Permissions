using Sanatana.Permissions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sanatana.Permissions.MVC
{
    public class UrlPermissionValidatorMVC<TUserKey, TKey>
        where TUserKey : struct
        where TKey : struct
    {
        //fields
        protected UrlPermissionValidator<TUserKey, TKey> _urlPermissionValidator;
        protected UrlHelper _urlHelper;


        //init
        public UrlPermissionValidatorMVC(UrlPermissionValidator<TUserKey, TKey> urlPermissionValidator
            , UrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }


        //methods
        public SecuredUrl GetActionPermission(string relativeUrl)
        {
            SecuredUrl securedUrl = ExtractActionFromUrl(relativeUrl);
            _urlPermissionValidator.CheckUrlPermission(securedUrl);
            return securedUrl;
        }

        protected SecuredUrl ExtractActionFromUrl(string relativeUrl)
        {
            SecuredUrl securedUrl = new SecuredUrl
            {
                Url = relativeUrl
            };

            // From relative to absolute uri
            Uri result;
            if (!Uri.TryCreate(relativeUrl, UriKind.Absolute, out result))
            {
                Uri baseUri = new Uri("http://www.contoso.com");
                Uri fullUri = new Uri(baseUri, relativeUrl);
                relativeUrl = fullUri.AbsoluteUri;
            }

            // Split the url to url + QueryString
            int questionMarkIndex = relativeUrl.IndexOf('?');
            string queryString = null;
            string url = relativeUrl;
            if (questionMarkIndex != -1)
            {
                url = relativeUrl.Substring(0, questionMarkIndex);
                queryString = relativeUrl.Substring(questionMarkIndex + 1);
            }

            // Arrange
            var request = new HttpRequest(null, url, queryString);
            var response = new HttpResponse(new StringWriter());
            HttpContext httpContext = new HttpContext(request, response);
            HttpContextBase httpContextBase = new HttpContextWrapper(HttpContext.Current);

            RouteData routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            if (routeData == null)
            {
                throw new Exception("Was not able to construct RouteData from url provided.");
            }

            // Extract from route values.
            RouteValueDictionary routeValue = routeData.Values;
            string areaName = (string)routeValue["area"] ?? string.Empty;
            string controllerName = (string)routeValue["controller"] ?? string.Empty;
            securedUrl.ActionName = (string)routeValue["action"] ?? string.Empty;

            IControllerFactory controllerFactory = ControllerBuilder.Current.GetControllerFactory();
            var requestContext = new RequestContext(httpContextBase, routeData);
            IController controller = (ControllerBase)controllerFactory.CreateController(requestContext, controllerName);
            securedUrl.ControllerFullName = controller.GetType().FullName;
            controllerFactory.ReleaseController(controller);

            if (securedUrl.ActionName != string.Empty)
            {
                return securedUrl;
            }

            var routeDataAsListFromMsDirectRouteMatches = (List<RouteData>)routeValue["MS_DirectRouteMatches"];
            var routeValueDictionaryFromMsDirectRouteMatches = routeDataAsListFromMsDirectRouteMatches.FirstOrDefault();
            if (routeValueDictionaryFromMsDirectRouteMatches == null)
            {
                return securedUrl;
            }

            securedUrl.ActionName = routeValueDictionaryFromMsDirectRouteMatches.Values["action"].ToString();
            if (securedUrl.ActionName == string.Empty)
            {
                securedUrl.ActionName = "Index";
            }
            return securedUrl;
        }

        public SecuredUrl GetActionPermission(string actionName, Type controllerType, RouteValueDictionary routeValues = null)
        {
            string controllerFullName = controllerType.FullName;
            return GetActionPermission(actionName, controllerFullName, routeValues);
        }

        public SecuredUrl GetActionPermission(string actionName, string controllerFullName, RouteValueDictionary routeValues = null)
        {
            string controllerName = GetShortControllerName(controllerFullName);
            string url = _urlHelper.Action(actionName, controllerName, routeValues);

            SecuredUrl securedUrl = new SecuredUrl()
            {
                Url = url,
                ActionName = actionName,
                ControllerFullName = controllerFullName
            };

            _urlPermissionValidator.CheckUrlPermission(securedUrl);
            return securedUrl;
        }

        protected string GetShortControllerName(string controllerFullName)
        {
            string[] controllerNameParts = controllerFullName
                .Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            string controllerName = controllerNameParts.Last();

            int suffixStart = controllerName.LastIndexOf("Controller");
            if(suffixStart != -1)
            {
                controllerName = controllerName.Substring(0, suffixStart);
            }
            return controllerName;
        }

    }
}
