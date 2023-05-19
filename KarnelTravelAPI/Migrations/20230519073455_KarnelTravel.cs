using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarnelTravelAPI.Migrations
{
    public partial class KarnelTravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Location_id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Tour_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tour_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Depature_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Times = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Tour_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    member_lever = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Charge_card = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Accommodation_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Accommodation_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Accommodation_id);
                    table.ForeignKey(
                        name: "FK_Accommodations_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationImages",
                columns: table => new
                {
                    Location_img_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImages", x => x.Location_img_id);
                    table.ForeignKey(
                        name: "FK_LocationImages_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Restaurant_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Restaurant_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Restaurant_id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TouristSpots",
                columns: table => new
                {
                    TouristSpot_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TouristSpot_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Activities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristSpots", x => x.TouristSpot_id);
                    table.ForeignKey(
                        name: "FK_TouristSpots_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Transport_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Transport_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Start_position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Transport_id);
                    table.ForeignKey(
                        name: "FK_Transports_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationImages",
                columns: table => new
                {
                    Accommodation_img_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accommodation_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationImages", x => x.Accommodation_img_id);
                    table.ForeignKey(
                        name: "FK_AccommodationImages_Accommodations_Accommodation_id",
                        column: x => x.Accommodation_id,
                        principalTable: "Accommodations",
                        principalColumn: "Accommodation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultiAccommodations",
                columns: table => new
                {
                    Accommodation_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tour_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiAccommodations", x => x.Accommodation_id);
                    table.ForeignKey(
                        name: "FK_MultiAccommodations_Accommodations_Accommodation_id",
                        column: x => x.Accommodation_id,
                        principalTable: "Accommodations",
                        principalColumn: "Accommodation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultiAccommodations_Tours_Tour_id",
                        column: x => x.Tour_id,
                        principalTable: "Tours",
                        principalColumn: "Tour_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultiRestaurants",
                columns: table => new
                {
                    Restaurant_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tour_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiRestaurants", x => x.Restaurant_id);
                    table.ForeignKey(
                        name: "FK_MultiRestaurants_Restaurants_Restaurant_id",
                        column: x => x.Restaurant_id,
                        principalTable: "Restaurants",
                        principalColumn: "Restaurant_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultiRestaurants_Tours_Tour_id",
                        column: x => x.Tour_id,
                        principalTable: "Tours",
                        principalColumn: "Tour_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantImages",
                columns: table => new
                {
                    Restaurant_img_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restaurant_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantImages", x => x.Restaurant_img_id);
                    table.ForeignKey(
                        name: "FK_RestaurantImages_Restaurants_Restaurant_id",
                        column: x => x.Restaurant_id,
                        principalTable: "Restaurants",
                        principalColumn: "Restaurant_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultiTouristSpots",
                columns: table => new
                {
                    TouristSpot_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tour_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiTouristSpots", x => x.TouristSpot_id);
                    table.ForeignKey(
                        name: "FK_MultiTouristSpots_TouristSpots_TouristSpot_id",
                        column: x => x.TouristSpot_id,
                        principalTable: "TouristSpots",
                        principalColumn: "TouristSpot_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultiTouristSpots_Tours_Tour_id",
                        column: x => x.Tour_id,
                        principalTable: "Tours",
                        principalColumn: "Tour_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TouristSpotImages",
                columns: table => new
                {
                    TouristSpot_img_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TouristSpot_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristSpotImages", x => x.TouristSpot_img_id);
                    table.ForeignKey(
                        name: "FK_TouristSpotImages_TouristSpots_TouristSpot_id",
                        column: x => x.TouristSpot_id,
                        principalTable: "TouristSpots",
                        principalColumn: "TouristSpot_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    booking_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Tour_id = table.Column<int>(type: "int", nullable: true),
                    Accommodation_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Restaurant_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TouristSpot_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Transport_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.booking_id);
                    table.ForeignKey(
                        name: "FK_Bookings_Accommodations_Accommodation_id",
                        column: x => x.Accommodation_id,
                        principalTable: "Accommodations",
                        principalColumn: "Accommodation_id");
                    table.ForeignKey(
                        name: "FK_Bookings_Restaurants_Restaurant_id",
                        column: x => x.Restaurant_id,
                        principalTable: "Restaurants",
                        principalColumn: "Restaurant_id");
                    table.ForeignKey(
                        name: "FK_Bookings_TouristSpots_TouristSpot_id",
                        column: x => x.TouristSpot_id,
                        principalTable: "TouristSpots",
                        principalColumn: "TouristSpot_id");
                    table.ForeignKey(
                        name: "FK_Bookings_Tours_Tour_id",
                        column: x => x.Tour_id,
                        principalTable: "Tours",
                        principalColumn: "Tour_id");
                    table.ForeignKey(
                        name: "FK_Bookings_Transports_Transport_id",
                        column: x => x.Transport_id,
                        principalTable: "Transports",
                        principalColumn: "Transport_id");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultiTransports",
                columns: table => new
                {
                    Transport_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tour_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiTransports", x => x.Transport_id);
                    table.ForeignKey(
                        name: "FK_MultiTransports_Tours_Tour_id",
                        column: x => x.Tour_id,
                        principalTable: "Tours",
                        principalColumn: "Tour_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultiTransports_Transports_Transport_id",
                        column: x => x.Transport_id,
                        principalTable: "Transports",
                        principalColumn: "Transport_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Feedback_id = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    booking_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Feedback_id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Bookings_Feedback_id",
                        column: x => x.Feedback_id,
                        principalTable: "Bookings",
                        principalColumn: "booking_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationImages_Accommodation_id",
                table: "AccommodationImages",
                column: "Accommodation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_Location_id",
                table: "Accommodations",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Accommodation_id",
                table: "Bookings",
                column: "Accommodation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Restaurant_id",
                table: "Bookings",
                column: "Restaurant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Tour_id",
                table: "Bookings",
                column: "Tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TouristSpot_id",
                table: "Bookings",
                column: "TouristSpot_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Transport_id",
                table: "Bookings",
                column: "Transport_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_User_id",
                table: "Bookings",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImages_Location_id",
                table: "LocationImages",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_MultiAccommodations_Tour_id",
                table: "MultiAccommodations",
                column: "Tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_MultiRestaurants_Tour_id",
                table: "MultiRestaurants",
                column: "Tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_MultiTouristSpots_Tour_id",
                table: "MultiTouristSpots",
                column: "Tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_MultiTransports_Tour_id",
                table: "MultiTransports",
                column: "Tour_id");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantImages_Restaurant_id",
                table: "RestaurantImages",
                column: "Restaurant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_Location_id",
                table: "Restaurants",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpotImages_TouristSpot_id",
                table: "TouristSpotImages",
                column: "TouristSpot_id");

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpots_Location_id",
                table: "TouristSpots",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_Location_id",
                table: "Transports",
                column: "Location_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationImages");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "LocationImages");

            migrationBuilder.DropTable(
                name: "MultiAccommodations");

            migrationBuilder.DropTable(
                name: "MultiRestaurants");

            migrationBuilder.DropTable(
                name: "MultiTouristSpots");

            migrationBuilder.DropTable(
                name: "MultiTransports");

            migrationBuilder.DropTable(
                name: "RestaurantImages");

            migrationBuilder.DropTable(
                name: "TouristSpotImages");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "TouristSpots");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
