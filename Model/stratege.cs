//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class stratege
    {
        public int StaId { get; set; }
        public string StaName { get; set; }
        public string StaRootUrl { get; set; }
        public Nullable<int> StaDeep { get; set; }
        public string StaStatus { get; set; }
    
        public virtual stratagedatacondition stratagedatacondition { get; set; }
        public virtual stratagepagecondition stratagepagecondition { get; set; }
    }
}
