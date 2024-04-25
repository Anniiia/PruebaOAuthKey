using PruebaOAuthKey.Models;
using Microsoft.EntityFrameworkCore;
using PruebaOAuthKey.Data;
using PruebaOAuthKey.Models;

namespace PruebaOAuthKey.Repositories
{
    public class RepositoryDoctores
    {
        private HospitalContext context;

        public RepositoryDoctores(HospitalContext context)
        {
            this.context = context;
        }

        public async Task RegisterUsuarioAsync(string email, string password, string nombre)
        {
            Usuario user = new Usuario();
            user.IdUsuairo = await this.GetMaxIdUsuarioAsync();
            user.Email = email;
            user.Password =password;
            user.Nombre = nombre;
            this.context.Usuarios.Add(user);
            await this.context.SaveChangesAsync();

        }

        private async Task<int> GetMaxIdUsuarioAsync()
        {
            if (this.context.Usuarios.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Usuarios.MaxAsync(z => z.IdUsuairo) + 1;
            }
        }
        public async Task<Usuario> FindUsuarioAsync(int idUsuario)
        {
            return await this.context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuairo == idUsuario);
        }

        //public async Task<Usuario> Perefil()
        //{
        //    return null;
        //}

        public async Task<Usuario> LoginUsuarioAsync(string email, string password) 
        {
            return await this.context.Usuarios.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        { 
            List<Doctor> doctores = await this.context.Doctores.ToListAsync();

            return doctores;
        }

        public async Task<Doctor> FindDoctorAsync(int idDoctor)
        {
            return await this.context.Doctores.FirstOrDefaultAsync(Z => Z.IdDoctor == idDoctor);
        }
        public async Task InsertDoctorAsync(Doctor doctor)
        { 
            Doctor doc = new Doctor();
            doc.IdHospital = doctor.IdHospital;
            doc.IdDoctor = doctor.IdDoctor;
            doc.Apellido = doctor.Apellido;
            doc.Especialidad = doctor.Especialidad;
            doc.Salario = doctor.Salario;
            this.context.Doctores.Add(doc);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(int idDoctor)
        { 
            Doctor doc = await this.FindDoctorAsync(idDoctor);
            this.context.Doctores.Remove(doc);
            await this.context.SaveChangesAsync();

        }

        public async Task UpdateDoctorAsync(int id, int idhospital, string apellido, string especialidad, int salario)
        {
            Doctor doc = await this.FindDoctorAsync(id);
            doc.IdHospital = idhospital;
            doc.Apellido = apellido;
            doc.Especialidad = especialidad;
            doc.Salario = salario;
            await this.context.SaveChangesAsync();
        }


        public async Task<List<string>> GetEspecialidadesAsync()
        { 
            List<string> especialidades = await this.context.Doctores.Select(x=>x.Especialidad).Distinct().ToListAsync();

            return especialidades;
        }

        public async Task<List<Doctor>> GetDoctoresEspecialidadAsync(string especialidad)
        { 
            List<Doctor> doctores = await this.context.Doctores.Where(x=>x.Especialidad==especialidad).ToListAsync();

            return doctores;
        }
    }
}
