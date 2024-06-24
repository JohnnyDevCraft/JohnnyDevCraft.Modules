using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;

namespace JohnnyDevCraft.Security.Module.Extensions;

public static class SecurityExtensions
{
    public static (IObjectSpace, PermissionPolicyRole) EnsureRole(this IObjectSpace space, string roleName, bool isAdmin = false, Action<PermissionPolicyRole> configure = null)
    {
        var role = space.FindObject<PermissionPolicyRole>(new BinaryOperator("Name", roleName));
        if (role == null)
        {
            role = space.CreateObject<PermissionPolicyRole>();
            role.Name = roleName;
            role.IsAdministrative = isAdmin;
            configure?.Invoke(role);
        }
        return (space, role);
    }
    
    public static (IObjectSpace, T) EnsureUser<T>(this IObjectSpace space, string userName,
        Action<T> configure = null) where T : PermissionPolicyUser
    {
        var user = space.FindObject<T>(new BinaryOperator("UserName", userName));
        if (user == null)
        {
            user = space.CreateObject<T>();
            user.UserName = userName;
            configure?.Invoke(user);
        }
        return (space, user);
    }
    
    public static (IObjectSpace, T) SetUserPassword<T>(this (IObjectSpace, T) tuple, string password) where T : PermissionPolicyUser
    {
        var (space, user) = tuple;
        user.SetPassword(password);
        return (space, user);
    }
    
    public static (IObjectSpace, T) AddRole<T>(this (IObjectSpace, T) input, string roleName) where T : PermissionPolicyUser
    {
        var (space, user) = input;
        var role = space.FindObject<PermissionPolicyRole>(new BinaryOperator("Name", roleName));
        if (role != null)
        {
            user.Roles.Add(role);
        }
        else
        {
            throw new UserFriendlyException($"Role not found. {roleName}");
        }
        
        return (space, user);
    }
    
    public static PermissionPolicyRole ReadOnlyAccess<T>(this PermissionPolicyRole role) where T : BaseObject, IOwned
    {
        role.AddObjectPermission<T>(SecurityOperations.ReadOnlyAccess, "[OwnerId] = CurrentUserId()", SecurityPermissionState.Allow);
        return role;
    }
    
    public static PermissionPolicyRole FullAccess<T>(this PermissionPolicyRole role) where T : BaseObject, IOwned
    {
        role.AddObjectPermission<T>(SecurityOperations.FullAccess, "[OwnerId] = CurrentUserId()", SecurityPermissionState.Allow);
        return role;
    }
    
    public static PermissionPolicyRole NavigationAccess<T>(this PermissionPolicyRole role) where T : BaseObject, IOwned
    {
        role.AddObjectPermission<T>(SecurityOperations.Navigate, "[OwnerId] = CurrentUserId()", SecurityPermissionState.Allow);
        return role;
    }
}