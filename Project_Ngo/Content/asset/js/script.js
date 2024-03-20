#myTable {
    counter - reset: rowNumber;
}

#myTable tbody tr {
    counter - increment: rowNumber;
}

#myTable tbody tr td: first - of - type::before {
    content: counter(rowNumber);
}