var totaltimeinseconts = 240;
var elapsedtime = 0;
var questions;
var correctAnswercount = 0;
var WrongAnswerCount = 0;
var NoAnswerCount = 0;


var i = 1;
var currentQuestion = 0;
var currentQuestionId = 0;



$(document).ready(function () {
    $('#loadingmessage').show();
    totaltimeinseconts = 240;
    elapsedtime = 0;
    questions;
    correctAnswercount = 0;
    WrongAnswerCount = 0;
    NoAnswerCount = 0;


    i = 1;
    currentQuestion = 0;
    currentQuestionId = 0;






    $("#Next").click(function () {
        if (currentQuestion == questions.length - 1) {
            $("#Next").hide()
        }
        var selectedanswer = $(".radio-inline").find("input[type=radio]:checked").val()

        setAnswer(currentQuestionId, selectedanswer);
        currentQuestion++;
        LoadQuestion();


    });



    $("#TryAgain").click(function () {



        location.reload();



    });



    $("#Submit").click(function () {


        SendAnswer()



    });








});


function GetData(uri, param) {
    var i = 1;

    $("#MainCont").empty();
    $('#loadingmessage').show();
    $.ajax({
        url: uri,
        type: 'GET',
        data: param,
        dataType: 'json',
        success: function (data, textStatus, xhr) {
            questions = data;
            currentQuestion = 0;
            LoadQuestion()

            totaltimeinseconts = (questions.length / 2) * 60;
            $("#timer").text("Time left: " + questions.length / 2 + " Minutes ");
            setInterval(myTimer, 60000);
            $('#loadingmessage').hide();

        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation');
        }
    });
}
function LoadQuestion() {
    $("#MainCont").html("");







    var val = questions[currentQuestion];


    currentQuestionId = val.QuestionId
    $("#MainCont").append("  <div class='row NewQst' id='\Q" + val.QuestionId.toString().trim() + "'><p class='well'> Question  :" + (currentQuestion + 1).toString() + "</p>   <p>" + val.FullQuestion + "</P> <p><strong> Options</strong></p> " +
      " <p> <label class=\"radio-inline\"><input type=\"radio\"name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption1 + "\"> " + val.AnswerOption1 + "</label></p>" +
      " <p><label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption2 + "\"> " + val.AnswerOption2 + "</label></p>" +
      " <p><label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"   value=\"" + val.AnswerOption3 + "\"> " + val.AnswerOption3 + "</label></p>" +
      " <p> <label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption4 + "\"> " + val.AnswerOption4 + "</label></p>" +
      "</div>");
}

function myTimer() {


    elapsedtime++;


    var remainingtime = totaltimeinseconts - elapsedtime;

    var remaininghour = Math.floor(remainingtime / 60)



    $("#timer").text("Time left: " + remaininghour + " Minutes ");

    if (remainingtime == 0) {
        Alert("Time Over: System Will Automatically Submit the Test");
    }


}







function setAnswer(id, newAnswer) {
    if (typeof (newAnswer) == 'undefined') {
        newAnswer = ""
    }
    for (var i = 0; i < questions.length; i++) {
        if (questions[i].QuestionId === id) {
            questions[i].UserAnswer = newAnswer;
            return;
        }
    }
}



function SendAnswer() {
    $('#loadingmessage').show();
    var uri1 = '/api/pmp/Post';
    $.ajax({
        url: uri1,
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(questions),
        success: function (data) {
            questions = data;
            ShowResult();
            LoadAnswers();
            $('#loadingmessage').hide();
        }
    });
}


function ShowResult() {

    for (var i = 0; i < questions.length; i++) {

        if (questions[i].isCorrect.trim() == "Y") {
            correctAnswercount++
        }
        else if (questions[i].isCorrect.trim() == "N") {
            WrongAnswerCount++
        }
        else if (questions[i].isCorrect.trim() == "S") {

            NoAnswerCount++;
        }

    }

    $("#MainCont").html("");

    $('#Submit').hide();
    $('#Next').hide();
    var rslt = "<h2>Result</h2><div class=\"panel panel-default\">" +
    "<div class=\"panel-heading\">Total Question :<strong> " + questions.length + " </Strong> </div>" +
        "<div class=\"panel-body\">Correct Answer :<strong>" + correctAnswercount.toString() + " </Strong> </div>" +
        "<div class=\"panel-body\">Wrong Answer :<strong>" + WrongAnswerCount.toString() + "</Strong> </div>" +
        "<div class=\"panel-body\">Not Attended :<strong> " + NoAnswerCount.toString() + " </Strong> </div>" +
      "</div>";

    $("#MainCont").append(rslt);
}


function LoadAnswers() {

    var i = 1;
    $.each(questions, function (index, val) {



        if (val.isCorrect == "Y") {
            $("#AnswerArea").append("  <div class='row NewQst' id='\Q" + val.QuestionId.toString().trim() + "'><p  style=\"background-color:Lightgreen;\"  class='well'> Question  :" + i.toString() + "</p>   <p>" + val.FullQuestion + "</P> <div class='Options'> <p><strong> Options</strong></p> " +
        " <p> <label class=\"radio-inline\"><input type=\"radio\"name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption1 + "\"> " + val.AnswerOption1 + "</label></p>" +
        " <p><label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption2 + "\"> " + val.AnswerOption2 + "</label></p>" +
        " <p><label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"   value=\"" + val.AnswerOption3 + "\"> " + val.AnswerOption3 + "</label></p>" +
        " <p> <label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption4 + "\"> " + val.AnswerOption4 + "</label></p></div>" +
        " <div class=\"Answerdiv\" > <p> <strong>Correct Answer : </strong> <div  class=\"CorrectAnswer\">" + val.CorrectAnswer.toString() + "</div></p> <p>Answer Explanation :  " + val.AnswerExplanation + " </p><p>Knowledge Area :  " + val.AreaofKnowledge + " </p></div>" +
        "</div>");
        }
        else {
            $("#AnswerArea").append("  <div  class='row NewQst' id='\Q" + val.QuestionId.toString().trim() + "'><p  style=\"background-color:palevioletred;\" class='well'> Question  :" + i.toString() + "</p>   <p>" + val.FullQuestion + "</P> <div class='Options'> <p><strong> Options</strong></p> " +
        " <p> <label class=\"radio-inline\"><input type=\"radio\"name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption1 + "\"> " + val.AnswerOption1 + "</label></p>" +
        " <p><label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption2 + "\"> " + val.AnswerOption2 + "</label></p>" +
        " <p><label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"   value=\"" + val.AnswerOption3 + "\"> " + val.AnswerOption3 + "</label></p>" +
        " <p> <label class=\"radio-inline\"><input type=\"radio\" name=\"optradioQ" + val.QuestionId.toString() + "\"  value=\"" + val.AnswerOption4 + "\"> " + val.AnswerOption4 + "</label></p></div>" +
        " <div class=\"Answerdiv\"> <p> <strong>Correct Answer : </strong> <div  class=\"CorrectAnswer\">" + val.CorrectAnswer.toString() + "</div></p> <p>Answer Explanation :  " + val.AnswerExplanation + " </p><p>Knowledge Area :  " + val.AreaofKnowledge + " </p></div>" +
        "</div>");
        }


        i++;



    });


}



