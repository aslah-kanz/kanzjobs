public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication("BasicAuthentication")
        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

    services.AddHangfire(config =>
    {
        config.UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"));
    });

    services.AddHangfireServer();
}

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseCookiePolicy();

    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseHangfireDashboard("/dashboard", new DashboardOptions
    {
        Authorization = new[] { new BasicAuthAuthorizationFilter("username", "password") }
    });

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });
}
