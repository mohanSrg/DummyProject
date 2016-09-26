namespace strange.extensions.implicitBind.api
{
  public interface IImplicitBinder
  {
    /// <summary>
    /// Search through indicated namespaces and scan for all annotated classes.
    /// Automatically create bindings.
    /// </summary>
    /// <param name="usingNamespaces">Array of namespaces. Compared using StartsWith. </param>

    void ScanForAnnotatedClasses (params string[] usingNamespaces);
  }
}
