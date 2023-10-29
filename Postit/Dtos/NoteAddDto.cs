using PostitDataAccessLibrary.Models;
using static QRCoder.PayloadGenerator;

namespace Postit.Dtos
{
    public class NoteAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }  
    }
}
