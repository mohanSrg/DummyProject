using UnityEngine;
using strange.framework.api;

namespace strange.extensions.mediation.api
{
  public interface IMediationBinder : IBinder
  {
    /// An event that just happened, and the View it happened to.
    /// If the event was Awake, it will trigger creation of a mapped Mediator.
    void Trigger (MediationEvent evt, IView view);

    /// Recast binding as IMediationBinding.
    new IMediationBinding Bind<T> ();

    /// Porcelain for Bind<T> providing a little extra clarity and security.
    IMediationBinding BindView<T> () where T : MonoBehaviour;
  }
}
