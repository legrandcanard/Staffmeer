
function validateInput(value) {
	if (value && value !== "0") {
		$("#btnCreateReport").removeClass("disabled");
		const url = new URL($("#btnCreateReport").attr("href"), location.origin);
		url.searchParams.set("id", value);
		$("#btnCreateReport").attr("href", url);
	}
	else {
		$("#btnCreateReport").addClass("disabled");
	}
}

$("#options-list").on("change", event => validateInput(event.target.value));

validateInput($("#options-list").val());