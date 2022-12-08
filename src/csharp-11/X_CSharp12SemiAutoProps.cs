using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_11
{
    public class CSharp12SemiAutoProps
    {

        public string? MyProperty { get; set; }


        private string? myPropertyBig;
        public string MyPropertyBig
        {
            get
            {
                return myPropertyBig;
            }

            set
            {
                myPropertyBig = value;
            }
        }


        private string? _lazyProperty;
        public string LazyProperty
        {
            get => _lazyProperty ??= "42";
            set => _lazyProperty = value;
        }
        //public string LazyProperty12 => field ??= "42";

        private string? _setOnceProperty;
        public string SetOnceProperty
        {
            get => _setOnceProperty;
            set
            {
                _setOnceProperty ??= value;
            }
        }
        //public string SetOnceProperty12
        //{
        //    get => field;
        //    set => field ??= value;
        //}

        public class AutoPropIssue
        {
            // Existing unrelated field
            private string field = "Barley";
            private string value = "Just for the explanation";
            public string SetOnceProperty12_Issue
            {
                get => field;
                set => field ??= value;
            }
            // In the `set` line above, are `field` and `value` referring to the implicit
            // ones or the fields? `value` refers to the implicit one and must remain so.
            //
            // a) Have the rules for `field` and `value` differ to preserve back compat?
            //    -- complicates the language forever
            // b) Use the `value` rule and give a warning 
            //    -- breaking change for perhaps thousands of users
            //    -- if the warning is ignored, the break may be subtle
            // c) Give a way to choose - like compat version for each project (see slide)
            //
            // If we do b) or c), should we reconsider other strange ones like `var`
            //    -- `var` is the one you know, unless there is a type by that name 

        }
    }
}
