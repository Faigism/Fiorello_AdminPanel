$(document).on("click", ".delete-btn", function (e) {
    e.preventDefault();
    let url = $(this).attr("href");
    Swal.fire({
        title: 'Silmək istədiyindən əminsən?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(url).then(response => {
                console.log(response)
                if (response.ok) {
                    Swal.fire(
                        'Silindi!',
                        'Your file has been deleted.',
                        'success'
                    ).then(() => {
                        window.location.reload();
                    })
                }
                else {
                    alert("xeta bas verdi!")
                }
            })
        }
    })
})
