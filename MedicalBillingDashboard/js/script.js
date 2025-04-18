// Payment Method Pie Chart
const pieCtx = document.getElementById('paymentPieChart').getContext('2d');
new Chart(pieCtx, {
  type: 'pie',
  data: {
    labels: ['Cash', 'Check', 'Credit', 'Insurance-Direct'],
    datasets: [{
      label: 'Payment Methods',
      data: [4, 2, 6, 3],
      backgroundColor: ['#f39c12', '#3498db', '#2ecc71', '#e74c3c']
    }]
  },
  options: {
    responsive: true,
    plugins: {
      legend: { position: 'bottom' }
    }
  }
});

// Bill Status Bar Chart
const barCtx = document.getElementById('billStatusBarChart').getContext('2d');
new Chart(barCtx, {
  type: 'bar',
  data: {
    labels: ['Paid', 'Partially Paid', 'Unpaid'],
    datasets: [{
      label: 'Bill Status Count',
      data: [7, 2, 3],
      backgroundColor: ['#2ecc71', '#f1c40f', '#e74c3c']
    }]
  },
  options: {
    responsive: true,
    scales: {
      y: { beginAtZero: true }
    }
  }
});

// Revenue Growth Line Chart
const lineCtx = document.getElementById('revenueLineChart').getContext('2d');
new Chart(lineCtx, {
  type: 'line',
  data: {
    labels: [
      'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct',
      'Nov', 'Dec', 'Jan', 'Feb', 'Mar', 'Apr'
    ],
    datasets: [{
      label: 'Monthly Revenue ($)',
      data: [1000, 1200, 1400, 1600, 1500, 1800, 2000, 1900, 2200, 2500, 2400, 2600],
      fill: false,
      borderColor: '#3498db',
      tension: 0.3
    }]
  },
  options: {
    responsive: true,
    scales: {
      y: { beginAtZero: true }
    }
  }
});
