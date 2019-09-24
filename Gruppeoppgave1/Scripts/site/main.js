$(function () {

    const debounce = (func, delay) => {
        let inDebounce
        return function () {
            const context = this
            const args = arguments
            clearTimeout(inDebounce)
            inDebounce = setTimeout(() => func.apply(context, args), delay)
        }
    }

    let stopQuery = function (input) {
        var data = JSON.stringify({
            query: `query ($stopInput: String!)  {
                    stopPlace(size: 5, stopPlaceType: railStation, query: $stopInput) {
                        id
                        name {
                            value
                        }
                    }
                }`,
            variables: { "stopInput": input.target.value }

        });
        $.ajax({
            method: "POST",
            contentType: "application/json",
            url: "https://api.entur.io/stop-places/v1/graphql",
            data: data,
            success: function (response) {
                var id = "#" + input.target.attributes.list.value;
                $(id).html("");
                response.data.stopPlace.forEach(function (item) {
                    $(id).append('<option data-value="' + item.id + '">' + item.name.value + '</option>');
                });
                console.log(response.data);
            },
            error: function (response) {
                console.log(response);
            }
        });
    }

    $('.stopInput').on('input', debounce(stopQuery, 250));

   



    /*
    var paramter = { url: "/Api" };
    var funksjonen = function (x) {
        alert(data)
    });
  
    $.ajax(paramter).done(funksjonen);
    */

});