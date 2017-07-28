function alert(alerttype, text) {
    switch (alerttype) {
        case "success":
            $.toast({
                heading: 'Success',
                text: text,
                position: 'top-right',
                icon: 'success'
            })
            break;
        case "error":
            $.toast({
                heading: 'Error',
                text: text,
                position: 'top-right',
                icon: 'error'
            })
            break;
        case "warning":
            $.toast({
                heading: 'Warning',
                text: text,
                position: 'top-right',
                icon: 'warning'
            })
            break;
        case "info":
            $.toast({
                heading: 'Information',
                text: text,
                position: 'top-right',
                icon: 'info'
            })
            break;
        default:

    }
}