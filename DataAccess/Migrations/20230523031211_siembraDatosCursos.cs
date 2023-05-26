using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class siembraDatosCursos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "CrMin", "Creditos", "Nombre", "Obligatorio", "PensumViejo", "PreRequisitos", "Semestre" },
                values: new object[,]
                {
                    { "1", 200, 4, "ETICA PROFESIONAL", false, true, " ", 9 },
                    { "10", 0, 2, "LOGICA", false, true, "19", 4 },
                    { "101", 0, 7, "MATE BASICA 1", true, true, " ", 1 },
                    { "103", 0, 7, "MATE BASICA 2", true, true, "101", 2 },
                    { "107", 0, 10, "MATE INTERMEDIA 1", true, true, "103", 3 },
                    { "11", 0, 2, "IDIOMA TECNICO 4", false, true, "9", 4 },
                    { "112", 0, 5, "MATE INTERMEDIA 2", true, true, "107", 4 },
                    { "114", 0, 5, "MATE INTERMEDIA 3", true, true, "107", 4 },
                    { "116", 0, 5, "MATE APLICADA 3", true, true, "112,114", 5 },
                    { "118", 0, 6, "MATE APLICADA 1", true, true, "112,114", 5 },
                    { "120", 0, 6, "MATE APLICADA 2", false, true, "118", 6 },
                    { "122", 0, 4, "MATE APLICADA 4", false, true, "118", 6 },
                    { "14", 0, 4, "ECONOMIA", true, true, "732", 6 },
                    { "147", 0, 5, "FISICA BASICA", true, true, "101", 2 },
                    { "150", 0, 5, "FISICA 1", true, true, "103,147", 3 },
                    { "152", 0, 6, "FISICA 2", true, true, "107,150", 4 },
                    { "17", 0, 4, "SOCIAL HUMANISTICA 1", true, true, " ", 1 },
                    { "18", 90, 3, "FILOSOFIA DE LA CIENCIA", false, true, "19", 5 },
                    { "19", 0, 4, "SOCIAL HUMANISTICA 2", true, true, "17", 2 },
                    { "200", 0, 5, "ING. ELECTRICA 1", false, true, "114,152", 6 },
                    { "2009", 200, 0, "PRACTICA FINAL", true, true, "2036", 9 },
                    { "2025", 0, 0, "PRACTICA INICIAL", true, true, "103,107", 4 },
                    { "2036", 0, 0, "PRACTICA INTERMEDIA", true, true, "778,777,773,2025", 7 },
                    { "28", 90, 3, "ECOLOGIA", false, true, " ", 5 },
                    { "281", 0, 5, "SISTEMAS OPERATIVOS 1", true, true, "781,778", 7 },
                    { "283", 0, 5, "ANALISIS Y DISENIO DE SISTEMAS 1", true, true, "774", 8 },
                    { "285", 0, 4, "SISTEMAS OPERATIVOS 2", true, true, "281", 8 },
                    { "288", 190, 4, "INTRODUCCION A LA EVALUACION DE IMPACTO AMBIENTAL", false, true, " ", 9 },
                    { "3022", 90, 0, "PSICOLOGIA INDUSTRIAL", false, true, " ", 6 },
                    { "335", 0, 3, "GESTION DE DESASTRES", false, true, "28", 6 },
                    { "348", 0, 3, "QUIMICA GENERAL 1", true, true, " ", 1 },
                    { "3658", 0, 0, "ADMINISTRACION DE PERSONAL", false, true, "3022", 7 },
                    { "3662", 90, 0, "LEGISLACION 1", false, true, " ", 6 },
                    { "3664", 0, 0, "LEGISLACION 2", false, true, "3662", 7 },
                    { "368", 0, 3, "PRINCIPIOS DE METROLOGIA", false, true, "732,152,348", 5 },
                    { "39", 0, 1, "DEPORTES 1", false, true, " ", 1 },
                    { "40", 0, 1, "DEPORTES 2", false, true, "39", 2 },
                    { "5", 0, 3, "TECNICAS DE ESTUDIO Y DE INVESTIGACION", true, true, " ", 2 },
                    { "6", 0, 2, "IDIOMA TECNICO 1", false, true, " ", 1 },
                    { "601", 0, 5, "INVESTIGACION DE OPERACIONES 1", true, true, "771,732", 6 },
                    { "603", 0, 5, "INVETIGACION DE OPERACIONES 2", true, true, "601", 7 },
                    { "650", 90, 3, "CONTABILIDAD 1", false, true, " ", 5 }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "CrMin", "Creditos", "Nombre", "Obligatorio", "PensumViejo", "PreRequisitos", "Semestre" },
                values: new object[,]
                {
                    { "652", 0, 3, "CONTABILIDAD 2", false, true, "650", 6 },
                    { "654", 0, 3, "CONTABILIDAD 3", false, true, "652", 7 },
                    { "656", 150, 5, "ADMINISTRACION DE EMPRESAS 1", false, true, " ", 7 },
                    { "69", 0, 3, "TECNICA COMPLEMENTARIA 1", true, true, " ", 1 },
                    { "700", 0, 5, "INGENIERIA ECONOMICA 1", false, true, "732", 7 },
                    { "702", 0, 4, "INGENIERIA ECONOMICA 2", false, true, "700", 9 },
                    { "706", 190, 4, "PREPARACION Y EVALUACION DE PROYECTOS 1", false, true, "700", 10 },
                    { "710", 190, 6, "PLANEAMIENTO", false, true, " ", 10 },
                    { "720", 0, 5, "MODELACION Y SIMULACION 2", true, true, "729", 10 },
                    { "722", 0, 5, "TEORIA DE SISTEMAS 1", true, true, "732,772,116,118", 6 },
                    { "724", 0, 5, "TEORIA DE SISTEMAS 2", true, true, "722,601,736", 7 },
                    { "729", 0, 5, "MODELACION Y SIMULACION 1", true, true, "724,603", 9 },
                    { "732", 0, 5, "ESTADISTICA 1", true, true, "107,5", 4 },
                    { "734", 0, 5, "ESTADISTICA 2", false, true, "732", 7 },
                    { "735", 0, 5, "AUDITORIA DE PROYECTOS DE SOFTWARE", false, true, "785", 10 },
                    { "736", 0, 4, "ANALISIS PROBABILISTICO", true, true, "732", 5 },
                    { "738", 0, 5, "BASES DE DATOS AVANZADAS", false, true, "775", 9 },
                    { "770", 33, 4, "INTRODUCCION A LA PROGAMACION Y COMPUTACION 1", true, true, "103", 3 },
                    { "771", 0, 5, "INTRODUCCION A LA PROGRAMACION Y COMPUTACION 2", true, true, "107,770,795,960", 4 },
                    { "772", 0, 5, "ESTRUCTURA DE DATOS", true, true, "771,796,962", 5 },
                    { "773", 0, 4, "MANEJO E IMPLEMENTACION DE ARCHIVOS", true, true, "772,796", 6 },
                    { "774", 0, 5, "SISTEMAS DE BASES DE DATOS 1", true, true, "773", 7 },
                    { "775", 0, 4, "SISTEMAS DE BASES DE DATOS 2", true, true, "281,774", 8 },
                    { "777", 0, 4, "ORGANIZACION DE LENGUAJES Y COMPILADORES 1", true, true, "771,796,962", 5 },
                    { "778", 0, 5, "ARQUITECTURA DE COMPUTADORES Y ENSAMBLADORES 1", true, true, "796,964", 6 },
                    { "779", 0, 4, "ARQUITECTURA DE COMPUTADORAS Y ENSAMBLADORES 2", true, true, "778", 7 },
                    { "780", 0, 6, "SOFTWARE AVANZADO", true, true, "785", 10 },
                    { "781", 0, 5, "ORGANIZACION DE LENGUAJES Y COMPILADORES 2", true, true, "777,772", 6 },
                    { "785", 0, 5, "ANALISIS Y DISENIO DE SISTEMAS 2", true, true, "283", 9 },
                    { "786", 0, 4, "SISTEMAS ORGANIZACIONALES GERENZIALES 1", true, true, "283,722", 9 },
                    { "787", 0, 4, "SISTEMAS ORGANIZACIONALES Y GERENCIALES 2", true, true, "786", 10 },
                    { "788", 0, 5, "SISTEMAS APLICADOS 1", false, true, "283", 9 },
                    { "789", 0, 5, "SISTEMAS APLICADOS 2", false, true, "785,788", 10 },
                    { "790", 0, 4, "EMPREDEDORES DE NEG. INFORMATICOS", false, true, "786", 10 },
                    { "795", 33, 2, "LOGICA DE SISTEMAS", true, true, "103", 3 },
                    { "796", 0, 3, "LENGUAJES FORMALES Y DE PROGRAMACION", true, true, "770,795,960", 4 },
                    { "797", 170, 3, "SEMINARIO DE SISTEMAS 1", true, true, "724", 8 },
                    { "798", 190, 3, "SEMINARIO DE SISTEMAS 2", true, true, "797", 9 },
                    { "799", 220, 3, "SEMINARIO DE INVESTIGACION", true, true, "798", 10 },
                    { "7990", 225, 4, "SEMINARIO DE INVESTIGACION EPS", false, true, " ", 10 },
                    { "8", 0, 2, "IDIOMA TECNICO 2", false, true, "101", 2 },
                    { "9", 0, 2, "IDIOMA TECNICO 3", false, true, "8", 3 }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "CrMin", "Creditos", "Nombre", "Obligatorio", "PensumViejo", "PreRequisitos", "Semestre" },
                values: new object[,]
                {
                    { "960", 33, 5, "MATE COMPUTO 1", true, true, "103", 3 },
                    { "962", 0, 5, "MATE COMPUTO 2", true, true, "960,770,795", 4 },
                    { "964", 0, 3, "ORGANIZACION COMPUTACIONAL", true, true, "152,771,962", 5 },
                    { "966", 0, 4, "SEGURIDAD Y AUDITORIA DE REDES", false, true, "975", 9 },
                    { "968", 0, 4, "INTELIGENCIA ARTIFICIAL 2", false, true, "972", 10 },
                    { "970", 0, 4, "REDES DE COMPUTADORAS 1", true, true, "773,778", 7 },
                    { "972", 0, 4, "INTELIGENCIA ARTIFICIAL 1", true, true, "781,775,724", 9 },
                    { "974", 0, 4, "REDES DE NUEVA GENERACION", false, true, "975", 10 },
                    { "975", 0, 4, "REDES DE COMPUTADORAS 2", true, true, "970", 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "101");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "103");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "107");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "112");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "114");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "116");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "118");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "120");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "122");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "14");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "147");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "150");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "152");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "17");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "18");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "19");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "200");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "2009");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "2025");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "2036");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "28");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "281");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "283");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "285");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "288");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "3022");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "335");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "348");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "3658");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "3662");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "3664");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "368");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "39");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "40");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "601");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "603");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "650");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "652");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "654");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "656");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "69");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "700");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "702");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "706");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "710");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "720");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "722");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "724");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "729");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "732");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "734");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "735");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "736");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "738");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "770");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "771");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "772");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "773");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "774");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "775");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "777");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "778");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "779");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "780");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "781");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "785");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "786");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "787");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "788");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "789");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "790");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "795");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "796");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "797");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "798");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "799");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "7990");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "960");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "962");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "964");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "966");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "968");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "970");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "972");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "974");

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: "975");
        }
    }
}
