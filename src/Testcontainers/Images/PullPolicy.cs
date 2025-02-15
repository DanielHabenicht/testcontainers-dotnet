namespace DotNet.Testcontainers.Images
{
  using System;
  using Docker.DotNet.Models;

  /// <summary>
  /// Pre-configured image pull policies.
  /// </summary>
  public static class PullPolicy
  {
    /// <summary>
    /// Gets the policy that never pulls images.
    /// </summary>
    public static Func<ImagesListResponse, bool> Never
    {
      get
      {
        return _ => false;
      }
    }

    /// <summary>
    /// Gets the policy that pulls missing images (not cached).
    /// </summary>
    public static Func<ImagesListResponse, bool> Missing
    {
      get
      {
        return cachedImage => cachedImage == null;
      }
    }

    /// <summary>
    /// Gets the policy that always pulls images.
    /// </summary>
    public static Func<ImagesListResponse, bool> Always
    {
      get
      {
        return _ => true;
      }
    }
  }
}
