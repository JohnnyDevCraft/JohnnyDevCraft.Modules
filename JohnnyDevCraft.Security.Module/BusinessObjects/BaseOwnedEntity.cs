using System.ComponentModel.DataAnnotations;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;

namespace JohnnyDevCraft.Security.Module.BusinessObjects;

public class BaseOwnedEntity: BaseObject, IOwned
{
    [Required]
    [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
    public virtual Guid OwnerId { get; set; }
}