using System.ComponentModel.DataAnnotations;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using JohnnyDevCraft.SmartCodes.Constants;
using Microsoft.Extensions.DependencyInjection;

using RequiredDA = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace JohnnyDevCraft.SmartCodes.BusinessObjects;

public class SmartCode : BaseObject
{
    [MinLength(2), MaxLength(100), RequiredDA]
    public virtual string Label { get; set; }
    
    [MinLength(2), MaxLength(5), RequiredDA]
    public virtual string Code { get; set; }

    [RequiredDA]
    public virtual Guid SmartTypeId { get; set; }
}