﻿namespace Superscribe.UnitTesting
{
    using Superscribe.Models;
    using Superscribe.Utils;

    public class RouteData : IRouteData
    {
        private string actionName;

        private string controllerName;

        public RouteData()
        {
            this.Parameters = new DynamicDictionary();
        }
        
        public dynamic Parameters { get; set; }

        public bool ActionNameSpecified { get; private set; }

        public string ActionName
        {
            get
            {
                return this.actionName;
            }
            set
            {
                this.ActionNameSpecified = true;
                this.actionName = value;
            }
        }

        public bool ControllerNameSpecified { get; private set; }

        public string ControllerName
        {
            get
            {
                return this.controllerName;
            }
            set
            {
                this.ControllerNameSpecified = true;
                this.controllerName = value;
            }
        }

        public object Response { get; set; }

        public bool ParamConversionError { get; set; }
        
        public T Bind<T>() where T : class
        {
            throw new System.NotImplementedException();
        }

        public T Require<T>() where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}
