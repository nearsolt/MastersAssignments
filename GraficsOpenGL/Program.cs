using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;
using OpenGL;

namespace GraficsOpenGL {

    class Program {

#if true
        #region task 1

        #region Initializing shaders
        private static string vertexShader = @"
in vec3 vertexPosition;
in vec3 vertexColor;

out vec3 color;

uniform mat4 projection_matrix;
uniform mat4 view_matrix;
uniform mat4 model_matrix;

void main(void){
    color = vertexColor;
    gl_Position = projection_matrix * view_matrix * model_matrix * vec4(vertexPosition, 1);
}
";

        private static string fragmentShader = @"                                           
in vec3 color;

out vec4 fragment;

void main(void){
    fragment = vec4(color, 1);
}
";
        #endregion

        #region Initializing variables
        private static int width = 800, height = 600;
        private static ShaderProgram program;
        private static VBO<Vector3> rectangle, circle, triangle;
        private static VBO<Vector3> rectangleColor, circleColor, circleBorderColor, triangleColor, triangleBorderColor;
        private static VBO<uint> rectangleElements, circleElements, triangleElements;
        #endregion

        #region Initializing Glut Idle callbacks
        private static void OnDisplay() {
            Gl.ClearColor(1f, 1f, 1f, 1f);
        }

        private static void OnRenderFrame() {
            Gl.Viewport(0, 0, width, height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Gl.UseProgram(program);

            // задаем позиции вершин, значения цвета и элементы прямоугольника
            program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0f, 0.35f, 0f)));
            Gl.BindBufferToShaderAttribute(rectangle, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(rectangleColor, program, "vertexColor");
            Gl.BindBuffer(rectangleElements);

            Gl.DrawElements(BeginMode.Quads, rectangleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // задаем позиции вершин, значения цвета и элементы круга
            program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0f, 1.2f, 0f)));
            Gl.BindBufferToShaderAttribute(circle, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(circleColor, program, "vertexColor");
            Gl.BindBuffer(circleElements);

            Gl.DrawElements(BeginMode.TriangleFan, circleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // задаем позиции вершин, значения цвета, элементы границы круга и толщину линии
            Gl.BindBufferToShaderAttribute(circle, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(circleBorderColor, program, "vertexColor");
            Gl.BindBuffer(circleElements);
            Gl.LineWidth(3f);

            Gl.DrawElements(BeginMode.LineLoop, circleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // задаем позиции вершин, значения цвета, элементы треугольника 
            program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0f, 0f, 0f)));
            Gl.BindBufferToShaderAttribute(triangle, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(triangleColor, program, "vertexColor");
            Gl.BindBuffer(triangleElements);

            Gl.DrawElements(BeginMode.Triangles, triangleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // задаем позиции вершин, значения цвета, элементы границы треугольника и толщину линии
            program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0f, 0f, 0f)));
            Gl.BindBufferToShaderAttribute(triangle, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(triangleBorderColor, program, "vertexColor");
            Gl.BindBuffer(triangleElements);
            Gl.LineWidth(3f);

            Gl.DrawElements(BeginMode.LineLoop, triangleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            Glut.glutSwapBuffers();
        }

        private static void OnClose() {
            // очищаем из памяти все созданные объекты
            rectangle.Dispose();
            rectangleColor.Dispose();
            rectangleElements.Dispose();

            circle.Dispose();
            circleColor.Dispose();
            circleBorderColor.Dispose();
            circleElements.Dispose();

            triangle.Dispose();
            triangleColor.Dispose();
            triangleBorderColor.Dispose();
            triangleElements.Dispose();

            program.DisposeChildren = true;
            program.Dispose();
        }
        #endregion

        static void Main(string[] args) {

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(width, height);
            Glut.glutCreateWindow("Main Window");

            Glut.glutIdleFunc(OnRenderFrame);
            Glut.glutDisplayFunc(OnDisplay);
            Glut.glutCloseFunc(OnClose);

            program = new ShaderProgram(vertexShader, fragmentShader);

            program.Use();
            program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));
            program["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(0f, 0f, 10f), Vector3.Zero, new Vector3(0f, 10f, 0f)));

            // инициализируем вершины, цвет, и элементы для прямоугольника
            rectangle = new VBO<Vector3>(new Vector3[] { new Vector3(-1.4f, 1f, 0f), new Vector3(1.4f, 1f, 0f), new Vector3(1.4f, -1f, 0f), new Vector3(-1.4f, -1f, 0f) });
            rectangleColor = new VBO<Vector3>(Enumerable.Repeat(new Vector3(0.44f, 0.44f, 0.47f), 4).ToArray());
            rectangleElements = new VBO<uint>(new uint[] { 0, 1, 2, 3 }, BufferTarget.ElementArrayBuffer);

            // инициализируем вершины, цвет (для круга и его границы), и элементы для круга
            int num = 100;
            float coef = 0.75f;
            Vector3[] tmp = new Vector3[num + 1];
            for (int i = 0; i < num; i++) {
                tmp[i] = new Vector3((float)Math.Sin(2 * Math.PI * i / num) * coef, (float)Math.Cos(2 * Math.PI * i / num) * coef, 0f);
            }
            tmp[num] = tmp[0];
            circle = new VBO<Vector3>(tmp);
            circleColor = new VBO<Vector3>(Enumerable.Repeat(new Vector3(1f, 0f, 0f), num + 1).ToArray());
            circleBorderColor = new VBO<Vector3>(Enumerable.Repeat(new Vector3(0.36f, 0.89f, 0.71f), num + 1).ToArray());
            circleElements = new VBO<uint>(Enumerable.Range(0, num + 1).Select(x => Convert.ToUInt32(x)).ToArray(), BufferTarget.ElementArrayBuffer);

            // инициализируем вершины, цвет (для треугольника и его границы), и элементы для треугольника
            triangle = new VBO<Vector3>(new Vector3[] { new Vector3(0f, 0.9f, 0f), new Vector3(-1f, -1f, 0f), new Vector3(1f, -1f, 0f) });
            triangleColor = new VBO<Vector3>(Enumerable.Repeat(new Vector3(0.36f, 0.89f, 0.71f), 3).ToArray());
            triangleBorderColor = new VBO<Vector3>(Enumerable.Repeat(new Vector3(0.98f, 0.96f, 0.23f), 3).ToArray());
            triangleElements = new VBO<uint>(new uint[] { 0, 1, 2 }, BufferTarget.ElementArrayBuffer);

            Glut.glutMainLoop();

        }
        #endregion
#endif

#if false
        #region task 2
        #region Initializing shaders
        private static string vertexShader = @"
in vec3 vertexPosition;
in vec3 vertexColor;

out vec3 color;

uniform mat4 projection_matrix;
uniform mat4 view_matrix;
uniform mat4 model_matrix;

void main(void){
    color = vertexColor;
    gl_Position = projection_matrix * view_matrix * model_matrix * vec4(vertexPosition, 1);
}
";

        private static string fragmentShader = @"                                           
in vec3 color;

out vec4 fragment;

void main(void){
    fragment = vec4(color, 1);
}
";
        #endregion

        #region Initializing variables
        private static int width = 800, height = 600;
        private static ShaderProgram program;
        private static VBO<Vector3> rectangle, circle, triangle;
        private static VBO<Vector3> rectangleColor, circleColor, circleBorderColor, triangleColor, triangleBorderColor;
        private static VBO<uint> rectangleElements, circleElements, triangleElements;
        #endregion

        #region Initializing Glut Idle callbacks
        private static void OnDisplay() {
            Gl.ClearColor(1f, 1f, 1f, 1f);
        }

        private static void OnRenderFrame() {
            Gl.Viewport(0, 0, width, height);
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Gl.UseProgram(program);

            // задаем позиции вершин, значения цвета и элементы прямоугольника
            program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0f, 0.35f, 0f)));
            Gl.BindBufferToShaderAttribute(rectangle, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(rectangleColor, program, "vertexColor");
            Gl.BindBuffer(rectangleElements);

            Gl.DrawElements(BeginMode.Quads, rectangleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // задаем позиции вершин, значения цвета и элементы круга
            program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0f, 1.2f, 0f)));
            Gl.BindBufferToShaderAttribute(circle, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(circleColor, program, "vertexColor");
            Gl.BindBuffer(circleElements);

            Gl.DrawElements(BeginMode.TriangleFan, circleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // задаем позиции вершин, значения цвета, элементы границы круга и толщину линии
            Gl.BindBufferToShaderAttribute(circle, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(circleBorderColor, program, "vertexColor");
            Gl.BindBuffer(circleElements);
            Gl.LineWidth(3f);

            Gl.DrawElements(BeginMode.LineLoop, circleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // задаем позиции вершин, значения цвета, элементы треугольника 
            program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0f, 0f, 0f)));
            Gl.BindBufferToShaderAttribute(triangle, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(triangleColor, program, "vertexColor");
            Gl.BindBuffer(triangleElements);

            Gl.DrawElements(BeginMode.Triangles, triangleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // задаем позиции вершин, значения цвета, элементы границы треугольника и толщину линии
            program["model_matrix"].SetValue(Matrix4.CreateTranslation(new Vector3(0f, 0f, 0f)));
            Gl.BindBufferToShaderAttribute(triangle, program, "vertexPosition");
            Gl.BindBufferToShaderAttribute(triangleBorderColor, program, "vertexColor");
            Gl.BindBuffer(triangleElements);
            Gl.LineWidth(3f);

            Gl.DrawElements(BeginMode.LineLoop, triangleElements.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);

            Glut.glutSwapBuffers();
        }

        private static void OnClose() {
            // очищаем из памяти все созданные объекты
            rectangle.Dispose();
            rectangleColor.Dispose();
            rectangleElements.Dispose();

            circle.Dispose();
            circleColor.Dispose();
            circleBorderColor.Dispose();
            circleElements.Dispose();

            triangle.Dispose();
            triangleColor.Dispose();
            triangleBorderColor.Dispose();
            triangleElements.Dispose();

            program.DisposeChildren = true;
            program.Dispose();
        }
        #endregion

        static void Main(string[] args) {

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInitWindowSize(width, height);
            Glut.glutCreateWindow("Main Window");

            Glut.glutIdleFunc(OnRenderFrame);
            Glut.glutDisplayFunc(OnDisplay);
            Glut.glutCloseFunc(OnClose);

            program = new ShaderProgram(vertexShader, fragmentShader);

            program.Use();
            program["projection_matrix"].SetValue(Matrix4.CreatePerspectiveFieldOfView(0.45f, (float)width / height, 0.1f, 1000f));
            program["view_matrix"].SetValue(Matrix4.LookAt(new Vector3(0f, 0f, 10f), Vector3.Zero, new Vector3(0f, 10f, 0f)));

            // инициализируем вершины, цвет, и элементы для прямоугольника
            rectangle = new VBO<Vector3>(new Vector3[] { new Vector3(-1.4f, 1f, 0f), new Vector3(1.4f, 1f, 0f), new Vector3(1.4f, -1f, 0f), new Vector3(-1.4f, -1f, 0f) });
            rectangleColor = new VBO<Vector3>(Enumerable.Repeat(new Vector3(0.44f, 0.44f, 0.47f), 4).ToArray());
            rectangleElements = new VBO<uint>(new uint[] { 0, 1, 2, 3 }, BufferTarget.ElementArrayBuffer);

            // инициализируем вершины, цвет (для круга и его границы), и элементы для круга
            int num = 100;
            float coef = 0.75f;
            Vector3[] tmp = new Vector3[num + 1];
            for (int i = 0; i < num; i++) {
                tmp[i] = new Vector3((float)Math.Sin(2 * Math.PI * i / num) * coef, (float)Math.Cos(2 * Math.PI * i / num) * coef, 0f);
            }
            tmp[num] = tmp[0];
            circle = new VBO<Vector3>(tmp);
            circleColor = new VBO<Vector3>(Enumerable.Repeat(new Vector3(1f, 0f, 0f), num + 1).ToArray());
            circleBorderColor = new VBO<Vector3>(Enumerable.Repeat(new Vector3(0.36f, 0.89f, 0.71f), num + 1).ToArray());
            circleElements = new VBO<uint>(Enumerable.Range(0, num + 1).Select(x => Convert.ToUInt32(x)).ToArray(), BufferTarget.ElementArrayBuffer);

            // инициализируем вершины, цвет (для треугольника и его границы), и элементы для треугольника
            triangle = new VBO<Vector3>(new Vector3[] { new Vector3(0f, 0.9f, 0f), new Vector3(-1f, -1f, 0f), new Vector3(1f, -1f, 0f) });
            triangleColor = new VBO<Vector3>(Enumerable.Repeat(new Vector3(0.36f, 0.89f, 0.71f), 3).ToArray());
            triangleBorderColor = new VBO<Vector3>(Enumerable.Repeat(new Vector3(0.98f, 0.96f, 0.23f), 3).ToArray());
            triangleElements = new VBO<uint>(new uint[] { 0, 1, 2 }, BufferTarget.ElementArrayBuffer);

            Glut.glutMainLoop();

        }
        #endregion
#endif

    }
}
