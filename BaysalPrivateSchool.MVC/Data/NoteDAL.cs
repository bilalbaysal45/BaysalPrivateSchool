using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BaysalPrivateSchool.MVC.Models;

namespace BaysalPrivateSchool.MVC.Data
{
    public static class NoteDAL
    {
        public static async Task<UpdateNoteViewModel> GeyById(int noteId)
        {
            using(var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://localhost:5156/getNote/{noteId}");
                if(response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    var rootNote = JsonSerializer.Deserialize<Root<UpdateNoteViewModel>>(contentResponse);
                    return rootNote.Data;
                }
            }
            return null;
        }
        public static async Task<NoteViewModel> Update(UpdateNoteViewModel updateNote)
        {
            var rootUpdatedNote = new Root<NoteViewModel>(); 
            using(var httpClient = new HttpClient())
            {
                var serializedNote = JsonSerializer.Serialize(updateNote);
                StringContent stringContent = new StringContent(serializedNote,Encoding.UTF8,"application/json");
                var response = await httpClient.PutAsync("http://localhost:5156/updateNote", stringContent);
                if(response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    rootUpdatedNote.Data = JsonSerializer.Deserialize<NoteViewModel>(contentResponse);
                    return rootUpdatedNote.Data;
                }
            }
            return null;
        }
        public static async Task<AddNoteViewModel> Create(AddNoteViewModel addNote)
        {
            using(var httpClient = new HttpClient())
            {
                var serializedNote = JsonSerializer.Serialize(addNote);
                StringContent stringContent = new StringContent(serializedNote,Encoding.UTF8,"application/json");
                var response = await httpClient.PostAsync("http://localhost:5156/addNote", stringContent);
                if(response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    var note = JsonSerializer.Deserialize<Root<AddNoteViewModel>>(contentResponse);
                    return note.Data;
                }
            }
            return null;
        }
        
    }
}