$("#BtnAddEquipe").click(function () {


    var check = $("#BtnAddEquipe").is(':checked');
    if (check == true) {
        $("#inp-equipe").html('<div><label>Les equipe</label><select class="form-select mb-3 " asp-for="idEquipe" id="showdata"><option>ajouter nouveau equipe</option></select><div>');
    } else {
        $("#inp-equipe").html('<div></div>')
    }
    var id = $("#showdata").attr('asp-for');
    $.ajax({
        url: "GetEquipe",
        type: "POST",
        dataType: "JSON",
        //contentType: false, // NEEDED, DON'T OMIT THIS (requires jQuery 1.6+)
        //processData: false, // NEEDED, DON'T OMIT THIS
        //    success: function (data) {
        //        for (var i = 0; i < data.length; i++) {
        //            var opt = $('<option></option>');
        //            opt.attr('value', data[i].id).text(data[i].nom_equipe);
        //            $("#showdata").append(opt);
        //        }



        //    }
        //});
        success: function (data) {
            var items = '';
            $.each(data, function (i, item) {
                var opt = $('<option></option>');
                 opt.attr('value', item.id).text(item.nom_equipe);
                  $("#showdata").append(opt);

            });

        }
    });

        /* display Categorie*/
        $("#type").change(function () {

            var check = $("#type").val();
            if (check == 'Ovrier') {
                $(".categorie").show();
            }
            else {
                $(".categorie").hide();
            }


        });
});