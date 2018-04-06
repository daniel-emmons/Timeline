using Rotorz.ReorderableList;
using UnityEditor;

[CustomEditor(typeof(ActorSchedule))]
public class ActorScheduleEditor : Editor {

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