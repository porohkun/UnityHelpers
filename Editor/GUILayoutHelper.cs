using System;

namespace UnityEngine
{
    public static class GUILayoutHelper
    {
        //
        // Summary:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // Parameters:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static IDisposable Area(Rect screenRect, string text, GUIStyle style)
        {
            GUILayout.BeginArea(screenRect, text, style);
            return new LayoutGrouper(GUILayout.EndArea);
        }
        //
        // Summary:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // Parameters:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static IDisposable Area(Rect screenRect, Texture image, GUIStyle style)
        {
            GUILayout.BeginArea(screenRect, image, style);
            return new LayoutGrouper(GUILayout.EndArea);
        }
        //
        // Summary:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // Parameters:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static IDisposable Area(Rect screenRect, GUIContent content, GUIStyle style)
        {
            GUILayout.BeginArea(screenRect, content, style);
            return new LayoutGrouper(GUILayout.EndArea);
        }
        //
        // Summary:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // Parameters:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static IDisposable Area(Rect screenRect, Texture image)
        {
            GUILayout.BeginArea(screenRect, image);
            return new LayoutGrouper(GUILayout.EndArea);
        }
        //
        // Summary:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // Parameters:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static IDisposable Area(Rect screenRect, string text)
        {
            GUILayout.BeginArea(screenRect, text);
            return new LayoutGrouper(GUILayout.EndArea);
        }
        //
        // Summary:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // Parameters:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static IDisposable Area(Rect screenRect)
        {
            GUILayout.BeginArea(screenRect);
            return new LayoutGrouper(GUILayout.EndArea);
        }
        //
        // Summary:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // Parameters:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static IDisposable Area(Rect screenRect, GUIStyle style)
        {
            GUILayout.BeginArea(screenRect, style);
            return new LayoutGrouper(GUILayout.EndArea);
        }
        //
        // Summary:
        //     Begin a GUILayout block of GUI controls in a fixed screen area.
        //
        // Parameters:
        //   text:
        //     Optional text to display in the area.
        //
        //   image:
        //     Optional texture to display in the area.
        //
        //   content:
        //     Optional text, image and tooltip top display for this area.
        //
        //   style:
        //     The style to use. If left out, the empty GUIStyle (GUIStyle.none) is used, giving
        //     a transparent background.
        //
        //   screenRect:
        public static IDisposable Area(Rect screenRect, GUIContent content)
        {
            GUILayout.BeginArea(screenRect, content);
            return new LayoutGrouper(GUILayout.EndArea);
        }
        //
        // Summary:
        //     Begin a Horizontal control group.
        //
        // Parameters:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Horizontal(params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(options);
            return new LayoutGrouper(GUILayout.EndHorizontal);
        }
        //
        // Summary:
        //     Begin a Horizontal control group.
        //
        // Parameters:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Horizontal(GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(style, options);
            return new LayoutGrouper(GUILayout.EndHorizontal);
        }
        //
        // Summary:
        //     Begin a Horizontal control group.
        //
        // Parameters:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Horizontal(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(text, style, options);
            return new LayoutGrouper(GUILayout.EndHorizontal);
        }
        //
        // Summary:
        //     Begin a Horizontal control group.
        //
        // Parameters:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Horizontal(Texture image, GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(image, style, options);
            return new LayoutGrouper(GUILayout.EndHorizontal);
        }
        //
        // Summary:
        //     Begin a Horizontal control group.
        //
        // Parameters:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Horizontal(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(content, style, options);
            return new LayoutGrouper(GUILayout.EndHorizontal);
        }
        //
        // Summary:
        //     Begin a vertical control group.
        //
        // Parameters:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Vertical(Texture image, GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(image, style, options);
            return new LayoutGrouper(GUILayout.EndVertical);
        }
        //
        // Summary:
        //     Begin a vertical control group.
        //
        // Parameters:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Vertical(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(text, style, options);
            return new LayoutGrouper(GUILayout.EndVertical);
        }
        //
        // Summary:
        //     Begin a vertical control group.
        //
        // Parameters:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Vertical(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(content, style, options);
            return new LayoutGrouper(GUILayout.EndVertical);
        }
        //
        // Summary:
        //     Begin a vertical control group.
        //
        // Parameters:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Vertical(params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(options);
            return new LayoutGrouper(GUILayout.EndVertical);
        }
        //
        // Summary:
        //     Begin a vertical control group.
        //
        // Parameters:
        //   text:
        //     Text to display on group.
        //
        //   image:
        //     Texture to display on group.
        //
        //   content:
        //     Text, image, and tooltip for this group.
        //
        //   style:
        //     The style to use for background image and padding values. If left out, the background
        //     is transparent.
        //
        //   options:
        //     An optional list of layout options that specify extra layouting properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Vertical(GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(style, options);
            return new LayoutGrouper(GUILayout.EndVertical);
        }


        private class LayoutGrouper : IDisposable
        {
            private Action _disposeAction;

            public LayoutGrouper(Action disposeAction)
            {
                _disposeAction = disposeAction;
            }

            void IDisposable.Dispose()
            {
                _disposeAction?.Invoke();
            }
        }
    }
}
