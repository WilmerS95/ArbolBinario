using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ArbolBinarioBlazor;
using ArbolBinarioBlazor.Services;
using ArbolBinario;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ArbolBinarioService>();

await builder.Build().RunAsync();