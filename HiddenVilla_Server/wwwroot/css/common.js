window.ShowToastr = (type, message) => {
    if (type == "success") {
        // Display a success toast, with a title
        toastr.success(message, 'Operation Successful', {
            timeOut: 3000
        })
    }
    if (type == "error") {
        // Display an error toast, with a title
        toastr.error(message, 'Operation Failed', {
            timeOut: 3000
        })
    }
}
window.SwalAlert = (type, message) => {
    if (type == "success") {
        // Display a success toast, with a title
        Swal.fire(
            'Good job!',
            message,
            'success'
        )
    }
    if (type == "error") {
        // Display an error toast, with a title
        Swal.fire(
            'Error!',
            message,
            'error'
        )
    }
}



