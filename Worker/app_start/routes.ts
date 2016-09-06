var documentController = require('../controllers/documentController.js');

export class Routes{
    public static registerRoutes(app) {
        app.use('/document', documentController);
    }
};

module.exports = Routes;