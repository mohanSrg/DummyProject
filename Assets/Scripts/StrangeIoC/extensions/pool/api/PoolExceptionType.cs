namespace strange.extensions.pool.api
{
  public enum PoolExceptionType
  {
    /// Pool has overflowed its limit
    OVERFLOW,
    /// Attempt to add an instance of different type to a pool
    TYPE_MISMATCH,
    /// A pool has no instance provider
    NO_INSTANCE_PROVIDER
  }
}
