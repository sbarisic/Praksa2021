let currentEvent;
const formatDate = date => date === null ? '' : moment(date).format("DD-MM-YYYY");
const fpStartTime = flatpickr("#StartTime", {
    enableTime: true,
    dateFormat: "d-m-Y h:i K"
});
const fpEndTime = flatpickr("#EndTime", {
    enableTime: true,
    dateFormat: "d-m-Y h:i K"
});

$('#calendar').fullCalendar({
    defaultView: 'month',
    height: 'parent',
    header: {
        left: 'prev,next today',
        center: 'title',
    },
    eventRender(event, $el) {
        $el.qtip({
            content: {
                title: event.title,
                text: event.description
            },
            hide: {
                event: 'unfocus'
            },
            show: {
                solo: true
            },
            position: {
                my: 'top left',
                at: 'bottom left',
                viewport: $('#calendar-wrapper'),
                adjust: {
                    method: 'shift'
                }
            }
        });
    },
    events: '/Works/GetCalendarEvents',
    eventClick: updateEvent,
    selectable: true,
    select: addEvent
});

/**
 * Calendar Methods
 **/

function updateEvent(event, element) {
    currentEvent = event;

    if ($(this).data("qtip")) $(this).qtip("hide");
    var isUser = $('#hdnIsUser').val();
    if (isUser == 1)
        $('#popupContent').load('Popup/' + event.eventId + '?isCalendar=' + 1);
    else
        $('#popupContent').load('EditPopup/' + event.eventId);

    $("#popupModal").modal('show');
}

function addEvent(start, end) {
    //$('#eventForm')[0].reset();
    start = moment(start).format('YYYY-MM-DD');
    //$('#popupContent').load('AddPopup/' + start);

    loadAddPopup(start);
}

/**
 * Modal
 * */

$('#eventModalSave').click(() => {
    const title = $('#EventTitle').val();
    const description = $('#Description').val();
    const startTime = moment($('#StartTime').val());
    const endTime = moment($('#EndTime').val());
    const isAllDay = $('#AllDay').is(":checked");
    const isNewEvent = $('#isNewEvent').val() === 'true' ? true : false;

    if (startTime > endTime) {
        alert('Start Time cannot be greater than End Time');

        return;
    } else if ((!startTime.isValid() || !endTime.isValid()) && !isAllDay) {
        alert('Please enter both Start Time and End Time');

        return;
    }

    const event = {
        title,
        description,
        isAllDay,
        startTime: startTime._i,
        endTime: endTime._i
    };

    if (isNewEvent) {
        sendAddEvent(event);
    } else {
        sendUpdateEvent(event);
    }
});

function sendAddEvent(event) {
    axios({
        method: 'post',
        url: '/Home/AddEvent',
        data: {
            "Title": event.title,
            "Description": event.description,
            "Start": event.startTime,
            "End": event.endTime,
            "AllDay": event.isAllDay
        }
    })
        .then(res => {
            const { message, eventId } = res.data;

            if (message === '') {
                const newEvent = {
                    start: event.startTime,
                    end: event.endTime,
                    allDay: event.isAllDay,
                    title: event.title,
                    description: event.description,
                    eventId
                };

                $('#calendar').fullCalendar('renderEvent', newEvent);
                $('#calendar').fullCalendar('unselect');

                $('#eventModal').modal('hide');
            } else {
                alert(`Something went wrong: ${message}`);
            }
        })
        .catch(err => alert(`Something went wrong: ${err}`));
}

function sendUpdateEvent(event) {
    axios({
        method: 'post',
        url: '/Home/UpdateEvent',
        data: {
            "EventId": currentEvent.eventId,
            "Title": event.title,
            "Description": event.description,
            "Start": event.startTime,
            "End": event.endTime,
            "AllDay": event.isAllDay
        }
    })
        .then(res => {
            const { message } = res.data;

            if (message === '') {
                currentEvent.title = event.title;
                currentEvent.description = event.description;
                currentEvent.start = event.startTime;
                currentEvent.end = event.endTime;
                currentEvent.allDay = event.isAllDay;

                $('#calendar').fullCalendar('updateEvent', currentEvent);
                $('#eventModal').modal('hide');
            } else {
                alert(`Something went wrong: ${message}`);
            }
        })
        .catch(err => alert(`Something went wrong: ${err}`));
}

$('#deleteEvent').click(() => {
    if (confirm(`Do you really want to delte "${currentEvent.title}" event?`)) {
        axios({
            method: 'post',
            url: '/Home/DeleteEvent',
            data: {
                "EventId": currentEvent.eventId
            }
        })
            .then(res => {
                const { message } = res.data;

                if (message === '') {
                    $('#calendar').fullCalendar('removeEvents', currentEvent._id);
                    $('#eventModal').modal('hide');
                } else {
                    alert(`Something went wrong: ${message}`);
                }
            })
            .catch(err => alert(`Something went wrong: ${err}`));
    }
});

$('#AllDay').on('change', function (e) {
    if (e.target.checked) {
        $('#EndTime').val('');
        fpEndTime.clear();
        this.checked = true;
    } else {
        this.checked = false;
    }
});

$('#EndTime').on('change', () => {
    $('#AllDay')[0].checked = false;
});