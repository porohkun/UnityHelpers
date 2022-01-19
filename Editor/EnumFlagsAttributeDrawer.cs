using UnityEngine;

namespace UnityEditor
{
    [CustomPropertyDrawer(typeof(EnumFlagAttribute))]
    public class EnumFlagsAttributeDrawer : PropertyDrawer
    {
        const float _mininumWidth = 50.0f;

        int _enumLength;
        float _enumWidth;

        int _numBtns;
        int _numRows;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SetDimensions(property);
            return _numRows * EditorGUIUtility.singleLineHeight + (_numRows - 1) * EditorGUIUtility.standardVerticalSpacing;
        }

        void SetDimensions(SerializedProperty property)
        {
            _enumLength = property.enumNames.Length;
            _enumWidth = (EditorGUIUtility.currentViewWidth - EditorGUIUtility.labelWidth - 20);

            _numBtns = Mathf.FloorToInt(_enumWidth / _mininumWidth);
            _numRows = Mathf.CeilToInt((float)_enumLength / (float)_numBtns);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SetDimensions(property);

            int buttonsIntValue = 0;
            bool[] buttonPressed = new bool[_enumLength];
            float buttonWidth = _enumWidth / Mathf.Min(_numBtns, _enumLength);

            EditorGUI.LabelField(new Rect(position.x, position.y, EditorGUIUtility.labelWidth, position.height), label);

            EditorGUI.BeginChangeCheck();

            for (int row = 0; row < _numRows; row++)
            {
                for (int btn = 0; btn < _numBtns; btn++)
                {
                    int i = btn + row * _numBtns;

                    if (i >= _enumLength)
                    {
                        break;
                    }

                    // Check if the button is/was pressed
                    if ((property.intValue & (1 << i)) == 1 << i)
                    {
                        buttonPressed[i] = true;
                    }

                    Rect buttonPos = new Rect(position.x + EditorGUIUtility.labelWidth + buttonWidth * btn, position.y + row * (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing), buttonWidth, EditorGUIUtility.singleLineHeight);
                    buttonPressed[i] = GUI.Toggle(buttonPos, buttonPressed[i], property.enumNames[i], EditorStyles.toolbarButton);

                    if (buttonPressed[i])
                        buttonsIntValue += 1 << i;
                }
            }

            if (EditorGUI.EndChangeCheck())
            {
                property.intValue = buttonsIntValue;
            }
        }
    }
}
