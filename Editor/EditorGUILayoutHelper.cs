using System;
using UnityEngine;
using UnityEngine.Internal;

namespace UnityEditor
{
    public static class EditorGUILayoutHelper
    {
        //
        // Summary:
        //     Begin a build target grouping and get the selected BuildTargetGroup back.
        public static IDisposable BuildTargetSelectionGrouping(out BuildTargetGroup targetGroup)
        {
            targetGroup = EditorGUILayout.BeginBuildTargetSelectionGrouping();
            return new LayoutGrouper(EditorGUILayout.EndBuildTargetSelectionGrouping);
        }
        //
        // Summary:
        //     Begins a group that can be be hidden/shown and the transition will be animated.
        //
        // Parameters:
        //   value:
        //     A value between 0 and 1, 0 being hidden, and 1 being fully visible.
        //
        // Returns:
        //     If the group is visible or not.
        public static IDisposable FadeGroup(out bool visible, float value)
        {
            visible = EditorGUILayout.BeginFadeGroup(value);
            return new LayoutGrouper(EditorGUILayout.EndFadeGroup);
        }
        public static IDisposable FoldoutHeaderGroup(ref bool foldout, string content, [DefaultValue("EditorStyles.foldoutHeader")] GUIStyle style = null, Action<Rect> menuAction = null, GUIStyle menuIcon = null)
        {
            foldout = EditorGUILayout.BeginFoldoutHeaderGroup(foldout, content, style, menuAction, menuIcon);
            return new LayoutGrouper(EditorGUILayout.EndFoldoutHeaderGroup);
        }
        public static IDisposable FoldoutHeaderGroup(ref bool foldout, GUIContent content, [DefaultValue("EditorStyles.foldoutHeader")] GUIStyle style = null, Action<Rect> menuAction = null, GUIStyle menuIcon = null)
        {
            foldout = EditorGUILayout.BeginFoldoutHeaderGroup(foldout, content, style, menuAction, menuIcon);
            return new LayoutGrouper(EditorGUILayout.EndFoldoutHeaderGroup);
        }
        //
        // Summary:
        //     Begin a horizontal group and get its rect back.
        //
        // Parameters:
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Horizontal(out Rect rect, params GUILayoutOption[] options)
        {
            rect = EditorGUILayout.BeginHorizontal(options);
            return new LayoutGrouper(EditorGUILayout.EndHorizontal);
        }
        //
        // Summary:
        //     Begin a horizontal group and get its rect back.
        //
        // Parameters:
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Horizontal(out Rect rect, GUIStyle style, params GUILayoutOption[] options)
        {
            rect = EditorGUILayout.BeginHorizontal(style, options);
            return new LayoutGrouper(EditorGUILayout.EndHorizontal);
        }
        //
        // Summary:
        //     Begin an automatically laid out scrollview.
        //
        // Parameters:
        //   scrollPosition:
        //     The position to use display.
        //
        //   alwayShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when the content inside the ScrollView is wider than the
        //     scrollview itself.
        //
        //   alwayShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when content inside the ScrollView is taller than the scrollview
        //     itself.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //
        //   alwaysShowHorizontal:
        //
        //   alwaysShowVertical:
        //
        //   background:
        //
        // Returns:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static IDisposable ScrollView(ref Vector2 scrollPosition, params GUILayoutOption[] options)
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, options);
            return new LayoutGrouper(EditorGUILayout.EndScrollView);
        }
        //
        // Summary:
        //     Begin an automatically laid out scrollview.
        //
        // Parameters:
        //   scrollPosition:
        //     The position to use display.
        //
        //   alwayShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when the content inside the ScrollView is wider than the
        //     scrollview itself.
        //
        //   alwayShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when content inside the ScrollView is taller than the scrollview
        //     itself.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //
        //   alwaysShowHorizontal:
        //
        //   alwaysShowVertical:
        //
        //   background:
        //
        // Returns:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static IDisposable ScrollView(ref Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options)
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, options);
            return new LayoutGrouper(EditorGUILayout.EndScrollView);
        }
        //
        // Summary:
        //     Begin an automatically laid out scrollview.
        //
        // Parameters:
        //   scrollPosition:
        //     The position to use display.
        //
        //   alwayShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when the content inside the ScrollView is wider than the
        //     scrollview itself.
        //
        //   alwayShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when content inside the ScrollView is taller than the scrollview
        //     itself.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //
        //   alwaysShowHorizontal:
        //
        //   alwaysShowVertical:
        //
        //   background:
        //
        // Returns:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static IDisposable ScrollView(ref Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options)
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, horizontalScrollbar, verticalScrollbar, options);
            return new LayoutGrouper(EditorGUILayout.EndScrollView);
        }
        public static IDisposable ScrollView(ref Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options)
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, style, options);
            return new LayoutGrouper(EditorGUILayout.EndScrollView);
        }
        //
        // Summary:
        //     Begin an automatically laid out scrollview.
        //
        // Parameters:
        //   scrollPosition:
        //     The position to use display.
        //
        //   alwayShowHorizontal:
        //     Optional parameter to always show the horizontal scrollbar. If false or left
        //     out, it is only shown when the content inside the ScrollView is wider than the
        //     scrollview itself.
        //
        //   alwayShowVertical:
        //     Optional parameter to always show the vertical scrollbar. If false or left out,
        //     it is only shown when content inside the ScrollView is taller than the scrollview
        //     itself.
        //
        //   horizontalScrollbar:
        //     Optional GUIStyle to use for the horizontal scrollbar. If left out, the horizontalScrollbar
        //     style from the current GUISkin is used.
        //
        //   verticalScrollbar:
        //     Optional GUIStyle to use for the vertical scrollbar. If left out, the verticalScrollbar
        //     style from the current GUISkin is used.
        //
        //   options:
        //
        //   alwaysShowHorizontal:
        //
        //   alwaysShowVertical:
        //
        //   background:
        //
        // Returns:
        //     The modified scrollPosition. Feed this back into the variable you pass in, as
        //     shown in the example.
        public static IDisposable ScrollView(ref Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options)
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, background, options);
            return new LayoutGrouper(EditorGUILayout.EndScrollView);
        }
        //
        // Summary:
        //     Begin a vertical group with a toggle to enable or disable all the controls within
        //     at once.
        //
        // Parameters:
        //   label:
        //     Label to show above the toggled controls.
        //
        //   toggle:
        //     Enabled state of the toggle group.
        //
        // Returns:
        //     The enabled state selected by the user.
        public static IDisposable ToggleGroup(ref bool toggle, string label)
        {
            toggle = EditorGUILayout.BeginToggleGroup(label, toggle);
            return new LayoutGrouper(EditorGUILayout.EndToggleGroup);
        }
        //
        // Summary:
        //     Begin a vertical group with a toggle to enable or disable all the controls within
        //     at once.
        //
        // Parameters:
        //   label:
        //     Label to show above the toggled controls.
        //
        //   toggle:
        //     Enabled state of the toggle group.
        //
        // Returns:
        //     The enabled state selected by the user.
        public static IDisposable ToggleGroup(ref bool toggle, GUIContent label)
        {
            toggle = EditorGUILayout.BeginToggleGroup(label, toggle);
            return new LayoutGrouper(EditorGUILayout.EndToggleGroup);
        }
        //
        // Summary:
        //     Begin a vertical group and get its rect back.
        //
        // Parameters:
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Vertical(out Rect rect, GUIStyle style, params GUILayoutOption[] options)
        {
            rect = EditorGUILayout.BeginVertical(style, options);
            return new LayoutGrouper(EditorGUILayout.EndVertical);
        }
        //
        // Summary:
        //     Begin a vertical group and get its rect back.
        //
        // Parameters:
        //   style:
        //     Optional GUIStyle.
        //
        //   options:
        //     An optional list of layout options that specify extra layout properties. Any
        //     values passed in here will override settings defined by the style.<br> See Also:
        //     GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        //     GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.
        public static IDisposable Vertical(out Rect rect, params GUILayoutOption[] options)
        {
            rect = EditorGUILayout.BeginVertical(options);
            return new LayoutGrouper(EditorGUILayout.EndVertical);
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
