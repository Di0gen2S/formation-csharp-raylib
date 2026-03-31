using Raylib_cs;

Raylib.InitWindow(800, 600, "Hello, Raylib!");
Raylib.SetTargetFPS(60);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);
    Raylib.DrawText("Hello, Raylib!", 240, 270, 48, Color.DarkBlue);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();