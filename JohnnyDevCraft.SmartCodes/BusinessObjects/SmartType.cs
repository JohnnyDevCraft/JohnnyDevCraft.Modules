using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using JohnnyDevCraft.SmartCodes.Constants;
using Microsoft.Extensions.DependencyInjection;

using RequiredDA = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace JohnnyDevCraft.SmartCodes.BusinessObjects;

public class SmartType : BaseObject
{
    [MinLength(2), MaxLength(100), RequiredDA]
    public virtual string Name { get; set; }
    
    [MinLength(2), MaxLength(500)]
    public virtual string Description { get; set; }

    [Aggregated] public virtual IList<SmartCode> SmartCodes { get; set; } = new ObservableCollection<SmartCode>();
}