function getTimeZone() {
    let timeZone = Intl.DateTimeFormat().resolvedOptions().timeZone;
    return timeZone;
}
