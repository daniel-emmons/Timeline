using Rotorz.ReorderableList;
using UnityEditor;

[CustomEditor(typeof(NPCSchedule))]
public class NPCScheduleEditor : Editor {

	private SerializedProperty m_schedule;

	private void OnEnable() {
        m_schedule = serializedObject.FindProperty("Schedule");
	}

	public override void OnInspectorGUI() {
		serializedObject.Update();

		ReorderableListGUI.Title("Schedule");
		ReorderableListGUI.ListField(m_schedule);

		serializedObject.ApplyModifiedProperties();
	}

}