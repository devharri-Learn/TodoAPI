using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TodoClient.Models;


        using (var client = new HttpClient())
        {

            client.BaseAddress = new Uri("https://localhost:7283");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            //HTTP GET
            var responseTask = client.GetAsync("api/TodoItems");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<TodoItemDTO[]>();
                readTask.Wait();

                var students = readTask.Result;

                foreach (var student in students)
                {
                    Console.WriteLine(student.Name);
                }
            }
            else
            {
                Console.WriteLine("oops");
            }
        }
Console.WriteLine("Press any key to POST");
        Console.ReadLine();
using (var client = new HttpClient())
{

    client.BaseAddress = new Uri("https://localhost:7283");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));

    //HTTP POST

    TodoItemDTO todoItemDTO = new TodoItemDTO() { Name = "CONSOLEPOSTTEST", IsComplete = false};

    var postTask = client.PostAsJsonAsync<TodoItemDTO>("api/TodoItems", todoItemDTO);
    postTask.Wait();

    var result = postTask.Result;
    if (result.IsSuccessStatusCode)
    {

        var readTask = result.Content.ReadAsAsync<TodoItemDTO>();
        readTask.Wait();

        var insertedStudent = readTask.Result;

        Console.WriteLine("Student {0} inserted with id: {1}", insertedStudent.Name, insertedStudent.Id);
    }
    else
    {
        Console.WriteLine(result.StatusCode);
    }
}
Console.WriteLine("Press any key to exit");
Console.ReadLine();

