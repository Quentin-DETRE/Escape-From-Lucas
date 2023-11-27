using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomGrabInteractable : XRGrabInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        MatchAttachmentPoints(args.interactorObject);
    }

    private void MatchAttachmentPoints(IXRSelectInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        {
            Transform attachTransform = ((XRDirectInteractor)interactor).attachTransform;
            transform.rotation = attachTransform.rotation;
            transform.position = attachTransform.position;
        }
    }
}
