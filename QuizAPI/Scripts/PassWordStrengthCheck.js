$(document).ready(function () {
    $('#inputsm').keyup(function () {

        $('#result').html(checkStrength($('#inputsm').val()))
    })
    function checkStrength(password) {
        var strength = 0
        if (password.length < 6) {
            $('#result').removeClass()
            $('#result').addClass('short')
            $('#Warning').html("")
            return 'Too short'
        }
        if (password.length > 7) strength += 1
        // If password contains both lower and uppercase characters, increase strength value.
        if (password.match(/([a-z].*[A-Z])|([A-Z].*[a-z])/)) strength += 1
        // If it has numbers and characters, increase strength value.
        if (password.match(/([a-zA-Z])/) && password.match(/([0-9])/)) strength += 1
        // If it has one special character, increase strength value.
        if (password.match(/([!,%,&,@,#,$,^,*,?,_,~])/)) strength += 1
        // If it has two special characters, increase strength value.
        if (password.match(/(.*[!,%,&,@,#,$,^,*,?,_,~].*[!,%,&,@,#,$,^,*,?,_,~])/)) strength += 1
        // Calculated strength value, we can return messages
        // If value is less than 2

        if (strength < 2) {
            $('#result').removeClass()
            $('#result').addClass('weak')
            $('#Warning').html("")
            return 'Very Weak :Change immediately Hackers will kiss you for this'
        } else if (strength == 2) {
            $('#result').removeClass()
            $('#result').addClass('weaker')
            $('#Warning').html("")
            return 'Moderately Weak :Change as soon as possible Hackers will offer you a tea '
        }
        else if (strength == 3) {
            $('#result').removeClass()
            $('#result').addClass('good')
            $('#Warning').html("Dont include your birthday,year,telephonenumber or other guessable personal details to password ")
            return 'Strong :Moderately Safer : Think of more stronger passwords  '
        }
        else if (strength == 4) {
            $('#result').removeClass()
            $('#result').addClass('better')
            $('#Warning').html("Dont include your birthday,year,telephonenumber or other guessable personal details to password ")
            return 'Moderately Stronger: Think of more stronger passwords and dont provide it to anybody   '
        }
        else if (strength == 5) {
            $('#result').removeClass()
            $('#result').addClass('strong')

            $('#Warning').html("Dont include your birthday,year,telephonenumber or other guessable personal details to password ")

            return 'Extremely Strong: You Nailed it..Now please dont write or save it anywhere accesible for others '
        }
        else {
            alert(strength)
            $('#result').removeClass()
            $('#result').addClass('strong')
            return 'Strong'
        }
    }
});