namespace OrderCreation.Core.Enums;

public enum ProtectionType
{
    /// <summary>
    /// No protection.
    /// </summary>
    None,

    /// <summary>
    /// Relative or distance based protection type.
    /// </summary>
    Relative,

    /// <summary>
    /// Absolute or price based protection type.
    /// </summary>
    Absolute
}