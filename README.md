# NameRestrictor
Restrict specific string on player names!

### Configuration
```xml
  <hexDefaultMessagesColor>#2BC415</hexDefaultMessagesColor>
  <shouldNotifyInvalidString>true</shouldNotifyInvalidString>
  <restrictedStrings>
    <RestrictedString>&lt;</RestrictedString>
    <RestrictedString>&gt;</RestrictedString>
    <RestrictedString>#</RestrictedString>
    <RestrictedString>sus</RestrictedString>
    <RestrictedString>.com</RestrictedString>
  </restrictedStrings>
```

### Translations
```xml
  <Translation Id="rejection_message" Value="Sorry you have invalid strings on your name!" />
  <Translation Id="rejection_notify_message" Value="Sorry, you can't have {0} on your name!" />
```