@If Request.IsAuthenticated Then
    @<text>Welcome <strong>@User.Identity.Name</strong>!
    [ @Html.ActionLink("Log Off", "LogOff", "Account") ]</text>
Else
    @:[ @Html.ActionLink("Log On", "LogOn", "Account") ]
End If
