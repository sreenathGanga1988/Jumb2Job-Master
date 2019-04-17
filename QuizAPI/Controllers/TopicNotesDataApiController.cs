using QuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizAPI.Controllers
{
    public class TopicNotesDataApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public TopicMasterVM Get(int id)
        {
            return TopicNotesRepo.GetNotes(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public List<TopicNoteCommentVM> Post(TopicNoteCommentVM topicNoteCommentVM)
        {
            return TopicNotesRepo.AddComment(topicNoteCommentVM);
        }
    }



    public class TopicMasterVM
    {
        public int TopicMasterId { get; set; }
        public int CertificationId { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public virtual List<TopicNoteVM> TopicNoteVMs { get; set; }

        public TopicNoteCommentVM newComment { get; set; }
    }


    public class TopicNoteVM
    {

        public int TopicNoteId { get; set; }

        public int TopicMasterId { get; set; }
        public string NoteTittle { get; set; }
        public string NoteDesc { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual List<TopicNoteCommentVM> TopicNoteCommentVMs { get; set; }
        public int NotesSequence { get; set; }
    }

    public class TopicNoteCommentVM
    {

        public int TopicNoteCommentId { get; set; }

        public int TopicNoteId { get; set; }

        public string TopicNoteCommentDesc { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }

    }




    public static class TopicNotesRepo
    {
        public static TopicMaster getTopicmasterdata(int id = 1)
        {
            using (QuizContext cntxt = new QuizContext())
            {
                return cntxt.TopicMasters.Find(id);
            }
        }




        public static TopicMasterVM GetNotes(int TopicID)
        {
            TopicMasterVM tpm = new TopicMasterVM();
            tpm.newComment = new TopicNoteCommentVM();
            using (QuizContext cntxt = new QuizContext())
            {

                var topic = cntxt.TopicMasters.Find(TopicID);

                if (topic != null)
                {
                    tpm.TopicName = topic.TopicName;
                    tpm.TopicDescription = topic.TopicDescription;
                    tpm.TopicMasterId = topic.TopicMasterId;
                }

                tpm.TopicNoteVMs = new List<TopicNoteVM>();

                var q = cntxt.TopicNotes.Where(u => u.TopicMasterId == TopicID).ToList();
                if (q != null)
                {
                    if (q.Count > 0)
                    {
                        foreach (var element in q)
                        {
                            TopicNoteVM tpnotes = new TopicNoteVM();
                            tpnotes.TopicNoteId = element.TopicNoteId;
                            tpnotes.NoteTittle = element.NoteTittle;
                            tpnotes.NoteDesc = element.NoteDesc;
                            tpnotes.AddedBy = element.AddedBy;
                            tpnotes.AddedDate = element.AddedDate;

                            var comments = cntxt.TopicNoteComments.Where(u => u.TopicNoteId == tpnotes.TopicNoteId).ToList();
                            tpnotes.TopicNoteCommentVMs = new List<TopicNoteCommentVM>();
                            if (comments != null)
                            {
                                if (comments.Count > 0)
                                {
                                    foreach (var comment in comments)
                                    {
                                        TopicNoteCommentVM tpnotescomment = new TopicNoteCommentVM();
                                        tpnotescomment.TopicNoteCommentId = comment.TopicNoteCommentId;
                                        tpnotescomment.TopicNoteCommentDesc = comment.TopicNoteCommentDesc;
                                        tpnotescomment.AddedDate = comment.AddedDate;
                                        tpnotescomment.AddedBy = comment.AddedBy;
                                        tpnotes.TopicNoteCommentVMs.Add(tpnotescomment);
                                    }
                                }
                            }


                            tpm.TopicNoteVMs.Add(tpnotes);



                        }
                    }



                }

            }

            return tpm;
        }

        public static List<TopicNoteCommentVM> AddComment(TopicNoteCommentVM topicNoteCommentVM)
        {
            List<TopicNoteCommentVM> mycomments = new List<TopicNoteCommentVM>();
            using (QuizContext cntxt = new QuizContext())
            {
                TopicNoteComment tpcomment = new TopicNoteComment();
                tpcomment.TopicNoteId = topicNoteCommentVM.TopicNoteCommentId;
                tpcomment.TopicNoteCommentDesc = topicNoteCommentVM.TopicNoteCommentDesc;
                tpcomment.AddedDate = DateTime.Now;
                tpcomment.AddedBy = topicNoteCommentVM.AddedBy;

                cntxt.TopicNoteComments.Add(tpcomment);
                cntxt.SaveChanges();






                var comments = cntxt.TopicNoteComments.Where(u => u.TopicNoteId == topicNoteCommentVM.TopicNoteId).ToList();
                if (comments != null)
                {
                    if (comments.Count > 0)
                    {
                        foreach (var comment in comments)
                        {
                            TopicNoteCommentVM tpnotescomment = new TopicNoteCommentVM();
                            tpnotescomment.TopicNoteCommentId = comment.TopicNoteCommentId;
                            tpnotescomment.TopicNoteCommentDesc = comment.TopicNoteCommentDesc;
                            tpnotescomment.AddedDate = comment.AddedDate;
                            tpnotescomment.AddedBy = comment.AddedBy;
                            mycomments.Add(tpnotescomment);
                        }
                    }
                }
            }

            return mycomments;
        }
    }





}