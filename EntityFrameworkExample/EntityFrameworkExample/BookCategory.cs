//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkExample
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookCategory
    {
        public int BookkCategoryId { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
    }
}
