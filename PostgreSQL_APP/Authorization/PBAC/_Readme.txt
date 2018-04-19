The IOpBaseAuthorizationStoreManagementService has no methods -- it just gets and returns 
an IOpBasedAuthorizationStoreManagementService service representing the whole Store.


The IOpBasedAuthorizationStoreManagementService inherits all its functionality from the 
base IOpBasedAuthorizationElementAdministrator<IOpBasedAuthorizationStore>, and therefore
can manage (Create, Delete, Update, etc.) IOpBasedAuthorizationStore elements.


The basic element is an IOpBasedAuthorizationElement, defining Name, Description, and access to an inner object.
This is the basis of IOpBasedAuthorizationElement, which can contains a collection of child elements.


IOpBasedAuthorizationElement
   IOpBasedAuthorizationParentElement

IOpBasedAuthorizationAppRole and IOpBasedAuthorizationAppTask both inherit from ...ParentElement as they can contain
child objects.


