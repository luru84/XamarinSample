// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace KitchenTimeriPhone
{
    [Register ("MyViewController")]
    partial class MyViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Add10MinButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Add10SecButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Add1MinButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Add1SecButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ClearButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel RemainingTimeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StartButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Add10MinButton != null) {
                Add10MinButton.Dispose ();
                Add10MinButton = null;
            }

            if (Add10SecButton != null) {
                Add10SecButton.Dispose ();
                Add10SecButton = null;
            }

            if (Add1MinButton != null) {
                Add1MinButton.Dispose ();
                Add1MinButton = null;
            }

            if (Add1SecButton != null) {
                Add1SecButton.Dispose ();
                Add1SecButton = null;
            }

            if (ClearButton != null) {
                ClearButton.Dispose ();
                ClearButton = null;
            }

            if (RemainingTimeLabel != null) {
                RemainingTimeLabel.Dispose ();
                RemainingTimeLabel = null;
            }

            if (StartButton != null) {
                StartButton.Dispose ();
                StartButton = null;
            }
        }
    }
}