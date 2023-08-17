using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

namespace Milhouzer.Civilian.Tasks
{
    public class TaskUI : MonoBehaviour
    {
        private TaskData data;
        public TaskData Data
        {
            get { return data; }
            set { data = value; }
        }

        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI duration;

        public void SetTask(TaskData data)
        {
            this.data = data;
            Repaint();
        }

        public void Repaint()
        {
            title.text = data.name;
            duration.text = data.executionTime.Hour + ":" + data.executionTime.Minute + " -> " + data.endTime.Hour + ":" + data.endTime.Minute;
        }
    }
}
