$(document).ready(function () {









    var i = 0



    var tabletext = "<table><thead><tr><th>Sl</th><th>Question</th><th>option1</th><th>option2</th><th>option3</th><th>option4</th><th>CorrectAnswer</th></tr></thead><tbody>";
    $('ol li').each(function (i) {
        var qstrn = $(this).contents().get(0).nodeValue
        var option1 = $(this).find('.radiobutton').eq(0).text().replace('(A)', '');
        var option2 = $(this).find('.radiobutton').eq(1).text().replace('(B)', '');
        var option3 = $(this).find('.radiobutton').eq(2).text().replace('(C)', '');
        var option4 = $(this).find('.radiobutton').eq(3).text().replace('(D)', '');
        var correctAnswer = '';



        $(this).find('.radiobutton').each(function () {




            if ($(this).css('color') == 'rgb(0, 153, 0)') {

                correctAnswer = $(this).text()

            }


        });

        correctAnswer = correctAnswer.replace('(A)', '').replace('(B)', '').replace('(C)', '').replace('(D)', '')

        i = i + 1;

        tabletext = tabletext + "<tr><td>" + i.toString() + "</td><td>" + qstrn.toString() + "</td><td>" + option1.toString() + "</td><td>" + option2.toString() + "</td><td>" + option3.toString() + "</td><td>" + option4.toString() + "</td><td>" + correctAnswer.toString() + "</td></tr>";





    });
    tabletext = tabletext + "</tbody></table>"
    $("#tablearea").append(tabletext);
});