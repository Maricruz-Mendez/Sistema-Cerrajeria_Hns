CREATE PROCEDURE sp_GetPWD(@Trabajador varchar(40)) as
  Begin tran
    Begin try
     SELECT CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contrasena))
	FROM Empleados WHERE NomUsuario=@Trabajador
      COMMIT
    END TRY
  BEGIN CATCH
	 ROLLBACK
	 RAISERROR('Dato ingresado incorrectamente',16,1)
  END CATCH
  GO

CREATE PROCEDURE sp_AgregarEmpleado(@NomUsu VARCHAR(20),@Nom VARCHAR(30),
@Ape_P VARCHAR(30), @Ape_M VARCHAR(30), @Contra VARCHAR(MAX), @F_Nac SMALLDATETIME,
@F_Reg SMALLDATETIME, @Direc VARCHAR(80), @Telefono VARCHAR(10)) as 
  Begin tran
    Begin try
     INSERT INTO Empleados(Nombre, NomUsuario, Contrasena, Apellido_P, Apellido_M, F_Nacimiento, F_Registro, Direccion, Telefono)
     values(@Nom, @NomUsu, ENCRYPTBYPASSPHRASE('Contrasena', @Contra), @Ape_P, @Ape_M, @F_Nac, @F_Reg, @Direc, @Telefono)
      COMMIT
    END TRY
  BEGIN CATCH
	 ROLLBACK
	 RAISERROR('No se pudo ingresar los datos de forma correcta',16,1)
  END CATCH
  GO

  --LLAMADA DEL PROCEDIMIENTO PARA AGREGAR DATOS
  --exec sp_AgregarEmpleado Mari, Mari, 123123, Men, Alv, '04-26-1999', '05-14-2020',conta#1313, 871212312
  --select * from Empleados