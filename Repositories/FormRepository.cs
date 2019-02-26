namespace form_registration.Repositories {
    public class FormRepository {
        private readonly ERDbContext _context;
        public FormRepository(ERDbContext context){
            _context = context;
        }
        public async Task<Form> Add(Form form){
            // use db function to add form
            await _context.Forms.AddAsync(form);
            await _context.SaveChangesAsync();
            return form;
        }

        public IEumerable<Form> GetAll(){
            return _context.Forms;
        }
        public async Task<Form> Find(int id){
            return await _context.Forms.SingleOrDefaultAsync(x => x.id == id);
        }
        public async Task<Form> Remove(int id){
            var form = await _context.Forms.SingleAsync(x => x.id == id);
            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();
            return form;
        }
        public async Task<Form> Update(Form form){
            _context.Forms.Update(form);
            await _context.SaveChangesAsync();
            return form;
        }
        public async Task<bool> Exists(int id){
            return await _context.Forms.AnyAsync(x => x.id == id);
        }
    }
}