$(document).ready(function () {
    $.unblockUI();
    var totaltimeinseconts = 240;
    var elapsedtime = 0;
    var questions;
    var correctAnswercount = 0;
    var WrongAnswerCount = 0;
    var NoAnswerCount = 0;
    //Store the total number of questions
    var totalQuestions = 0;

    //Set the current question to display to 1
    var currentQuestion = 0;





    $('#MainCont').on('click', '.showAnswer', function () {
        // Do something on an existent or future .dynamicElement
        if ($(this).text() == "Show Answer") {
            $(this).closest("div").find(".Answerdiv").css("background-color", "Lightgreen");
            $(this).closest("div").find(".Answerdiv").show();
            $(this).text("Hide Answer");
        } else {
            $(this).closest("div").find(".Answerdiv").hide();
            $(this).text("Show Answer");
        }

    });




    $('#checkboxOption').change(function () {

        if ($(this).prop('checked') == true) {
            alert("Hiding Options");
            $('.Options').hide();
        }
        else {
            alert("Showing Options");
            $('.Options').show();
        }
    })


});



function GetData(uri, param) {
    var i = 1;
    $.blockUI({ message: '<h1>Loading Questions</h1>' }); 
    $("#MainCont").empty();
   
    $.ajax({
        url: uri,
        type: 'GET',
        data: param,
        dataType: 'json',
        success: function (data, textStatus, xhr) {
            questions = data;

            $.each(data, function (index, val) {


                $("#MainCont").append("  <div class='row NewQst' id='\Q" + val.QuestionId.toString().trim() + "'><p class='well'> Question  :" + val.QuestionId.toString() + "</p>   <p>" + val.FullQuestion + "</P> <div class='Options'> <p><strong> Options</strong></p> " +
                  " <p> <label class=\"radio-inline\"><input type=\"radio\"name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption1 + "\"> " + val.AnswerOption1 + "</label></p>" +
                  " <p><label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption2 + "\"> " + val.AnswerOption2 + "</label></p>" +
                  " <p><label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"   value=\"" + val.AnswerOption3 + "\"> " + val.AnswerOption3 + "</label></p>" +
                  " <p> <label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption4 + "\"> " + val.AnswerOption4 + "</label></p></div>" +
                  " <div class=\"Answerdiv\"  style=\"background-color:Lightgreen;display:none;\"> <p> <strong>Correct Answer : </strong> <div  class=\"CorrectAnswer\">" + val.CorrectAnswer.toString() + "</div></p> <p>Answer Explanation :  " + val.AnswerExplanation + " </p><p>Knowledge Area :  " + val.AreaofKnowledge + " </p></div>" +
                  "<p class=\"showAnswer\" style=\"color:Red;\">Show Answer</p>" +
                  "</div>");

                i++;

                

            });

            $.unblockUI();
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation');
        }
    });
}







window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("new50Qstn").style.display = "block";
    } else {
        document.getElementById("new50Qstn").style.display = "none";
    }
}



// When the user clicks on the button, scroll to the top of the document
function Reload() {
 $(document).scrollTop(0);
    location.reload();
}


