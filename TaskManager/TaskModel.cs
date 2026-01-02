using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TaskManager
{
    class TaskChildren
    {
        [JsonProperty("attached")]
        public List<TaskModel> Attached { get; set; } = new List<TaskModel>();
    }
    internal class TaskModel
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("markers")]
        public Dictionary<string, string> Markers { get; set; } = new Dictionary<string, string>();
        [JsonProperty("children")]
        public TaskChildren Children { get; set; } = new TaskChildren();
        public string TimeCreatedString
        {
            get
            {
                return new DateTime(TimeCreated).ToString("yyyy-MM-dd");
            }
        }
        public long TimeCreated { get; set; }
        public long TimeStart { get; set; }
        public long TimeEnd { get; set; }
        public TaskModel(string title)
        {
            ID = Guid.NewGuid().ToString();
            TimeCreated = DateTime.Now.Ticks;
            this.Title = title;
        }
    }
}
