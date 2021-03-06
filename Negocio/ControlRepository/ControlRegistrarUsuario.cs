﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Dominio.EntidadesDelDominio.Abstractas;
using Dominio.EntidadesDelDominio.Entidades;
using Negocio.ILogicaNegocio;



namespace Negocio.ControlRepository
{
    public class ControlRegistrarUsuario : IControlRegistrarUsuario
    {

        /// <summary>
        /// Consulta si un usuario a partir de la cedula, ya se encuentra registrado en la base de datos
        /// </summary>
        /// <param name="cedulaUsuario">Parámetro númerico con la cedula a  consultar en la base de datos</param>
        /// <returns>Valor tipo booleano </returns>
        public bool ConsultarUsuario(string cedulaUsuario)
        {
            using (RoomServicesEntities entidades = new RoomServicesEntities()) 
            {
               
                var consulta= (from item in entidades.Usuarios where (item.cedula.Equals(cedulaUsuario)) select item).ToList();

                
                if (consulta.Count()==0)
                {
                    return true;
                }
                else {
                    return false;
                }
                
            }
       
        }

        /// <summary>
        /// Ingresa un nuevo usuario en la base de datos 
        /// </summary>
        /// <param name="cedulaUsuario">Parámetro númerico con la cedula a  consultar en la base de datos</param>
        /// <returns>Valor tipo booleano </returns>

        public Boolean RegistrarUsuario(string cedula, string nombre, string apellido, DateTime? fecha, string nacionalidad, char genero, string email, string contrasena, string tipoPerfil)
        {

            using (RoomServicesEntities entidades = new RoomServicesEntities())
            {

                if (this.ConsultarUsuario(cedula) == true &&
                    (tipoPerfil.Equals("ADMINISTRADOR") | 
                    tipoPerfil.Equals("ARRENDADOR") | 
                    tipoPerfil.Equals("ARRENDATARIO")))
                {
                    Usuarios usuario = new Usuarios()
                    {

                        cedula = cedula,
                        nombre = nombre,
                        apellido = apellido,
                        fechaNacimiento = fecha,
                        nacionalidad = nacionalidad,
                        genero = char.ToString(genero),

                        
                    };
                    entidades.Usuarios.Add(usuario);
                    entidades.SaveChanges();
                    CuentasUsuarios cuenta = new CuentasUsuarios()
                    {
                        cedulaUsuario= usuario.cedula,
                        email = email,
                        contrasena = contrasena,

                    };
                    entidades.CuentasUsuarios.Add(cuenta);
                   
        
                    entidades.SaveChanges();

                    if (tipoPerfil.Equals("ADMINISTRADOR"))
                    {

                        Administradores admin = new Administradores()
                        {
                            cedula = cedula,
                            nombre = nombre,
                            apellido = apellido,
                        };
                        entidades.Administradores.Add(admin);
                        entidades.SaveChanges();

                    }
                    else if (tipoPerfil.Equals("ARRENDADOR"))
                    {

                        Arrendadores arrend = new Arrendadores()
                        {
                            idArrendador = Int32.Parse(cedula),
                            cedula = cedula,
                        };

                        entidades.Arrendadores.Add(arrend);
                        entidades.SaveChanges();

                    }
                    else if (tipoPerfil.Equals("ARRENDATARIO"))
                    {

                        Arrendatarios arrendatarios = new Arrendatarios()
                        {
                            idArrendatario = Int32.Parse(cedula),
                            tipoArrendador = "Huesped",
                            cedulaArrendatario = cedula,
                        };

                        entidades.Arrendatarios.Add(arrendatarios);
                        entidades.SaveChanges();
                    }
               

                    return true;
                }
                else
                {
                    return false;
                }
            };

        }

            
            
    }
}
    

