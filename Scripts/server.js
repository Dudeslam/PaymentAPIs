import (requirejs) from "./requirejs";
const http = require("https");
const express = require('express')
const app = express()
const port = 44337
const fs = require('fs');
const requirejs = require("./require");

// Host static html pages and JavaScripts
// from the "public" subdirectory
app.use(express.static('public'))

app.get('/create-payment', (req, res) => {

	const options = {
		"method": "POST",
		"hostname": "test.api.dibspayment.eu",
		"port": 443,
		"path": "/v1/payments",
		"headers": {
			"content-type": "application/json",
			"Authorization": "test-secret-key-578ecae112ad4012a00a39f6abf85de2"
		}
	};

	const restreq = http.request(options, function (resp) {
		const chunks = [];

		console.log("statusCode: ", resp.statusCode);
		console.log("headers: ", resp.headers);

		resp.on("data", function (chunk) {
			console.log("on data");
			chunks.push(chunk);
		});
		resp.on("end", function () {
			const body = Buffer.concat(chunks);
			console.log(body.toString());
			res.send(body.toString());
		});
	});

	// Read hard-coded payload from file in this example.
	// This is where you would normally generate a 
	// json object dynamically based on the current order.
	let payload = fs.readFileSync('payload.json');
	restreq.write(payload);
	// console.log(JSON.parse(payload));

	restreq.on('error', function (e) {
		console.error('error');
		console.error(e);

	});
	restreq.end();
})

app.listen(port, () => {
	console.log(`Server listening on port ${port}`)
})